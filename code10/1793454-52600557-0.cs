    const int maxColumnWidth = 5;
    static void ShowMatrix(int[,] matrix, string name)
    {
        var startColumn = Console.CursorLeft;
        var startRow = Console.CursorTop;
        Console.SetCursorPosition(startColumn, startRow);
        Console.Write($"{name}:");
        Console.SetCursorPosition(startColumn, ++startRow); // <-- Note this increments the row
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(maxColumnWidth));
            }
            Console.SetCursorPosition(startColumn, ++startRow); // <-- increment row again
        }
    }
