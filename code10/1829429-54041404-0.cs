        static void Main(string[] args)
        {
            int[,] grid = new int[7, 4];
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    grid[x, y] = x * y;
                }
            }
            PrintGrid(grid);
            int numberOfShuffles = 5;
            Random rand = new Random();
            for (int i = 0; i < numberOfShuffles; i++)
            {
                int x1 = rand.Next(0, grid.GetLength(0));
                int x2 = rand.Next(0, grid.GetLength(0));
                int y1 = rand.Next(0, grid.GetLength(1));
                int y2 = rand.Next(0, grid.GetLength(1));
                Console.WriteLine();
                Console.WriteLine("Swapping ({0},{1}) with ({2},{3})", x1,y1,x2,y2);
                Swap(x1,y1,x2,y2,ref grid);
                PrintGrid(grid);
            }
        }
        public static void Swap(int x1, int y1, int x2, int y2, ref int[,] grid)
        {
            int temp = grid[x1, y1]; // store the value we're about to replace
            grid[x1, y1] = grid[x2, y2]; // replace the value
            grid[x2, y2] = temp; // push the stored value into the other spot
        }
        private static void PrintGrid(int[,] grid)
        {
            Console.WriteLine("****************************");
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    Console.Write("|" + grid[x, y] + "| ");
                }
                Console.WriteLine();
            }
        }
