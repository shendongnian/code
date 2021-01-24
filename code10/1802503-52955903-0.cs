        static void Main(string[] args)
        {
            int[][] test = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };
             for(int i = 0; i < test.Length; i++)
            {
                for (int j = 0; j < test[i].Length; j++)
                {
                    Console.WriteLine($"Index: [{i},{j}]: {test[i][j]}");
                }
            }
        }
