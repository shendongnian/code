    public static class IEnumerableExtensions
    {
        public static bool ContainsAll<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            var items = source.ToHashSet();
            return other.All(items.Contains);
        }
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
    }
