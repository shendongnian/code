     class Program
        {
            static void Main(string[] args)
            {
                int rows = 12, cols = 480;
                double[,] nums = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        nums[i, j] = j;
                    }
                }
    
                CreateCSV(nums);
            }
    
            private static void CreateCSV(double[,] myArray)
            {
                var rows = myArray.GetLength(0);
                var cols = myArray.GetLength(1);
    
                using (StreamWriter file = new StreamWriter("2dArrayOut.csv"))
                {
                    file.AutoFlush = true;
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            file.Write($"{myArray[i, j]},");
                        }
                        file.Write("\n");
                    }
                }
            }
        }
