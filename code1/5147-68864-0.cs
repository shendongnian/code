    public static class IEnumerableUtils
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach(T item in collection)
                action(item);
        }
    }
