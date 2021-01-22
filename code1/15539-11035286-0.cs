    public static class CollectionHelper
    {
        public static IEnumerable<T> Add<T>(this IEnumerable<T> sequence, T item)
        {
            return (sequence ?? Enumerable.Empty<T>()).Concat(new[] { item });
        }
        public static T[] AddRangeToArray<T>(this T[] sequence, T[] items)
        {
            return (sequence ?? Enumerable.Empty<T>()).Concat(items).ToArray();
        }
        public static T[] AddToArray<T>(this T[] sequence, T item)
        {
            return Add(sequence, item).ToArray();
        }
    }
