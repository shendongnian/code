    private static int[,] GetMatrixValues(int rows, int columns)
    {
        var matrix = new int[rows, columns];
        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                matrix[row, column] =
                   GetIntegerFromUser($"Enter matrix value [{row}, {column}]");
            }
        }
    }
