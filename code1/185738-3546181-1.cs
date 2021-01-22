    double[,] arr = new double[list.Count, list[0].Length];
    for (int i = 0; i < list.Count; i++)
    {
        for (int j = 0; j < list[0].Length; j++)
        {
            arr[i, j] = list[i][j];
        }
    }
