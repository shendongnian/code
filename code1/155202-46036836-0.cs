    public static class Array2dExt
    {
        public static IEnumerable<IEnumerable<T>> Rows<T>(this T[,] array)
        {
            for (int r = array.GetLowerBound(0); r <= array.GetUpperBound(0); ++r)
                yield return row(array, r);
        }
        static IEnumerable<T> row<T>(T[,] array, int r)
        {
            for (int c = array.GetLowerBound(1); c <= array.GetUpperBound(1); ++c)
                yield return array[r, c];
        }
    }
