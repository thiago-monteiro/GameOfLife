using System;
using System.Threading;

namespace Conway_s_Game_of_Life
{
    class Program
    {
        public static System.Random random = new System.Random();
        public static bool[,] world = new bool[40, 81];
        public static bool[,] temp = new bool[40, 81];
        public static int H = world.GetLength(0);
        public static int W = world.GetLength(1);
        static void Main(string[] args)
        {
            for(var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    world[i, j] = randomBool();
                }
                   
            } 
            turn();
        }

        public static bool randomBool()
        {
            bool result = random.Next(1, 11) > 9;
            return result;
        }

        public static void display()
        {
            Console.WriteLine("Welcome to ripoff Conway's Game of Life!\n");
            for (var i = 0; i < H; i++)
            {
                string currentLine = "";
                for (var j = 0; j < W; j++)
                {
                    if (world[i, j])
                    {
                        currentLine += "* ";
                    }
                    else
                    {
                        currentLine += "  ";
                    }
                }
                Console.WriteLine(currentLine);
            }
        }

        public static int checkNeighbors(int row, int col)
        {
            int found = 0;

            // North

            if (row - 1 >= 0 && world[row - 1, col])
            {
                found++;
            }

            // South

            if (row + 1 <= H - 1 && world[row + 1, col])
            {
                found++;
            }

            // West

            if (col - 1 >= 0 && world[row, col - 1])
            {
                found++;
            }

            // East

            if (col + 1 <= W - 1 && world[row, col + 1])
            {
                found++;
            }

            // SouthEast

            if (row + 1 <= H - 1 && col + 1 <= W - 1 && world[row + 1, col + 1])
            {
                found++;
            }

            // SouthWest

            if (row + 1 <= H - 1 && col - 1 >= 0 && world[row + 1, col - 1])
            {
                found++;
            }

            // NorthEast

            if (row - 1 >= 0 && col + 1 <= W - 1 && world[row - 1, col + 1])
            {
                found++;
            }

            // NorthWest

            if (row - 1 >= 0 && col - 1 >= 0 && world[row - 1, col - 1])
            {
                found++;
            }

            return found;
        }

        public static bool isAlive(int found, int i, int j)
        {

            return (world[i, j] && found == 2) || (found == 3);
        }
        
        public static void scanWorld()
        {
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    temp[i, j] = isAlive(checkNeighbors(i, j), i, j);
                }
            }

            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < W; j++)
                {
                    world[i, j] = temp[i, j];
                }
            }
        }

        public static void turn()
        {
            while (true)
            {
                Console.Clear();
                display();

                scanWorld();

                Thread.Sleep(500);
            }
            
        }
    }
}
