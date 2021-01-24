    private static void ListData<T>(string[,] matrix)
    {
        for (var l = 0; l < matrix.GetLength(0); l++)
        {
            var array = new string[matrix.GetUpperBound(1)];
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = matrix[l, i];
            }
            PrintRow(array);
        }
        
        PrintLine();
    }
