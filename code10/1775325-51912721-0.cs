      private static void ListData<T>(string[,] matrix)
            {
                var array = new string[matrix.GetUpperBound(1)];
                for (int j = 0; j < array.GetUpperBound(0); j++)
                {
                    for (var i = 0; i < array.Length; i++)
                    {
                        array[i] = matrix[j, i];
                    }
    
                    PrintRow(array);
                    PrintLine();
                }
            }
