            int NumberOfColumns = 10;
            int NumberOfRows = 10;
            bool[,] Matrix = new bool[NumberOfRows, NumberOfColumns];
            Random rng  = new Random();
            for (int i = 0; i < NumberOfRows; i++)
            {
                for (int j = 0; j < NumberOfColumns; j++)
                {
                    if (rng.Next(0, 2) == 1)
                    {
                        Matrix[i,j] = true;
                    }
                    else
                    {
                        Matrix[i,j] = false;
                    }
                }
            }
