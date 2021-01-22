    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> ie, T item)
        {
            return ie.Concat(new T[] { item });
        }
    }
