    public static class TwoDimensionalArrayExt
    {
        public static IEnumerable<IEnumerable<T>> Rows<T>(this T[,] array)
        {
            return array.Cast<T>().Batch(array.GetLength(1));
        }
    }
