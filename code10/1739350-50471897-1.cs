        static void Main(string[] args)
        {
            int numberOfPanes = 50;
            var myGrid1 = GenerateGrid1(20, 20, numberOfPanes);
            var myGrid2 = GenerateGrid2(20, 20, numberOfPanes);
        }
        public static Object[,,] GenerateGrid1(int x, int y, int numberOfPanes)
        {
            var grid = new Object[x, y, numberOfPanes];            
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int k = 0; k < numberOfPanes; k++)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        grid[i, j, k] = rand.Next(1, 20);
                    }
                }
            }
            return grid;
        }
        public static List<int[,]> GenerateGrid2(int x, int y, int numberOfPanes)
        {
            var grid = new int[x, y];
            var multiPanes = new List<int[,]>();
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            for (int k = 0; k < numberOfPanes; k++)
            {
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        grid[i, j] = rand.Next(1, 20);
                    }
                }
                multiPanes.Add(grid);
            }
            return multiPanes;
        }
