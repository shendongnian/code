    int total = 0;
            // Iterate first dimension of the array
            for (int i = 0; i < nums.GetLength(0); i++)
            {
                // Iterate second dimension
                for (int j = 0; j < nums.GetLength(1); j++)
                {
                    total *= array[i, j];
                }
            }
    Console.WriteLine(total);
