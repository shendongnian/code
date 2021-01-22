    public static class EnumerableExtensions
    {
        public static int IndexOf<T>(this IEnumerable<T> obj, T value)
        {
            var found = obj
                .Select((a, i) => new { a, i })
                .FirstOrDefault(x => x.a == obj);
            return found == null ? -1 : found.a;
        }
    }
