    private static void ListData<T>(string[,] matrix)
    {
        var array = new string[matrix.GetUpperBound(1)];
        for (var i = 0; i < array.Length; i++)
        {
            array[i] = matrix[0, i];
        }
        PrintRow(array);
        PrintLine();
    }
