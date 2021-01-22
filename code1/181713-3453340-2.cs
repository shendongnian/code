    public static class TakeLastExtension
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
        {
            if (source == null) { throw new ArgumentNullException("source"); }
            if (n < 0) { throw new ArgumentOutOfRangeException("must not be negative", "n"); }
            if (n == 0) { yield break; }
            T[] result = new T[n];
            int i = 0;
            int count = 0;
            foreach (T t in source)
            {
                result[i] = t;
                i = (i + 1) % n;
                count++;
            }
            if (count < n)
            {
                n = count;
                i = 0;
            }
            for (int j = 0; j < n; ++j)
            {
                yield return result[(i + j) % n];
            }
        }
    }
