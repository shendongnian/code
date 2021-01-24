    public static class Extensions
    {
        public static bool Exist<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            return items.Any(predicate);
        }
    }
