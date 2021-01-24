    int[][,] array = new[]
    {
        new int[2, 2],
        new int[3, 3],
        new int[4, 4]
    };
    foreach (var table in array)
    {
        for (int j = 0; j < table.GetLength(1); j++)
            for (int i = 0; i < table.GetLength(0); i++)
                table[i, j] = i * j; // feed in some value
    }
