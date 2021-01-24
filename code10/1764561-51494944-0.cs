    public static class Extensions
    {
        public static IEnumerable<T> SelectAll<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items.Where(predicate);
        }
    }
