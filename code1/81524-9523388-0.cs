    public static class EnumerableExtensions
    {
        public static IEnumerable<TKey> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> selector)
        {
            return source.GroupBy(selector).Select(x => x.Key);
        }
    }
