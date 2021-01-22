    public static class Extensions
    {
        public static int MaxIndex<T>(this IEnumerable<T> TSource)
        {
            int i = -1;
            using (var iterator = TSource.GetEnumerator())
                while (iterator.MoveNext())
                    i++;
            return i;
        }
    }
