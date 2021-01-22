    public static class IEnumerableExtensions
    {
        public static bool HasSameContentsAs<T>(this ICollection<T> source,
                                                ICollection<T> other)
        {
            if (source.Count != other.Count)
            {
                return false;
            }
            var s = source
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            var o = other
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            int count;
            return s.Count == o.Count &&
                   s.All(x => o.TryGetValue(x.Key, out count) &&
                              count == x.Value);
        }
    }
