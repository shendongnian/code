    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> sources, params T[] items)
        {
            foreach (var item in items)
                yield return item;
            if (sources == null)
                yield break;
            foreach (var source in sources)
                yield return source;
        }
    }
