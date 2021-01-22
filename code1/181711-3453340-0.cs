    public static class TakeLastExtension
    {
        public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> e, int n)
        {
            T[] result = new T[n];
            int i = 0;
            foreach (T t in e)
            {
                result[i] = t;
                i = (i + 1) % n;
            }
            for (int j = 0; j < n; ++j)
            {
                yield return result[(i + j) % n];
            }
        }
     
    }
