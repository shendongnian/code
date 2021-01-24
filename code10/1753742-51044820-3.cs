    public static class QueryableExtensions
    {
        public static IQueryable<T> AsMaybeTracking<T>(this IQueryable<T> source, bool isTracked = false) where T : class
        {
            return isTracked ? source.AsTracking() : source.AsNoTracking();
        }
    }
