    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> ie, T item)
        {
             return new T[] { item }.Concat(ie);
        }
    }
