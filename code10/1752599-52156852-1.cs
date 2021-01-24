        public int Max(int[,] values)
        {
            int max = 0;
            for (int i = 1; i < values.GetLength(0); i++)
            {
                for (int j = 1; j < values.GetLength(1); j++)
                {
                    if (values[i,j] > 0)
                    {
                        max = values[i, j];
                    }
                }
            }
            return max;
        }
        public int Min(int[,] values)
        {
               ... ... ...
                    if (values[i].CompareTo(max) < 0)
                    {
                        max = values[i];
                    }
               ... ... ...
            return max;
        }
