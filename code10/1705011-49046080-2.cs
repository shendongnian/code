    int sum= 0;
    int mul= 0;
                // Iterate first dimension of the array
                for (int i = 0; i < nums.GetLength(0); i++)
                {
                    // Iterate second dimension
                    for (int j = 0; j < nums.GetLength(1); j++)
                    {
                        sum += array[i, j];
                        mul *= array[i, j];
                    }
                }
    
        Console.WriteLine("SUM = " + sum);
        Console.WriteLine("MUL = " + mul);
