    public static Tuple<int, int> CoordinatesOf(Cell[,] cells, Cell value)
    {
        int w = cells.GetLength(0); // width
        int h = cells.GetLength(1); // height
        for (int i = 0; i < w; ++i)
        {
            for (int j = 0;j < h; ++j)
            {
                if (cells[i, j] == value)
                     return Tuple.Create(i, j);
            }
        }
         return Tuple.Create(-1, -1);
    }
