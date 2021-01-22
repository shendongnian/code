    public static class EnumerableEx
    {
        public static IEnumerable<IEnumerable<T>> AsPages<T>(
            this IEnumerable<T> set, int pageLength)
        {
            using (var e = set.GetEnumerator())
                while (true)
                    yield return GetPage(e, pageLength);
        }
        private static IEnumerable<T> GetPage<T>(
           IEnumerator<T> set, int pageLength)
        {
            for (var position = 0; 
                position < pageLength && set.MoveNext(); 
                position++)
                yield return set.Current;
        }
    }
