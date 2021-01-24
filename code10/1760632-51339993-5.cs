    public static IEnumerable<T> Column<T>(T[,] array, int column)
    {
        for (int row = array.GetLowerBound(0); row <= array.GetUpperBound(0); ++row)
            yield return array[row, column];
    }
    public static IEnumerable<IEnumerable<T>> ByColumn<T>(T[,] array)
    {
        for (int column = array.GetLowerBound(1); column <= array.GetUpperBound(1); ++column)
            yield return Column(array, column);
    }
