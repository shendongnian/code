    internal static class ArrayExt
    {
        public static IEnumerable<int> Indices(this Array array, int dimension)
        {
            for (var i = array.GetLowerBound(dimension); i <= array.GetUpperBound(dimension); i++)
            {
                yield return i;
            }
        }
    }
