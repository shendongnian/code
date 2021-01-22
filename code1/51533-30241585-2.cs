    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> source, params T[] items)
        {
            return items.Concat(source ?? new T[0]);
        }
    }
