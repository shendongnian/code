    static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> func)
        {
            foreach (T item in items)
            {
                func(item);
            }
        }
    }
