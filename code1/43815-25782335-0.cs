    public static class LinqExtensions
    {
        public static IEnumerable<T> GetNth<T>(this IEnumerable<T> list, int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n");
            if (n > 0)
            {
                int c = 0;
                foreach (var e in list)
                {
                    if (c % n == 0)
                        yield return e;
                    c++;
                }
            }
        }
        public static IEnumerable<T> GetNth<T>(this IList<T> list, int n)
        {
            if (n < 0)
                throw new ArgumentOutOfRangeException("n");
            if (n > 0)
                for (int c = 0; c < list.Count; c += n)
                    yield return list[c];
        }
    }
