    public static class QueryableExtensions
    {
        public static IQueryable AsMaybeTracking(IQueryable source, bool isTracked = false)
        {
            return isTracked ? source : source.AsNoTracking();
        }
        public static IQueryable<T> AsMaybeTracking<T>(this IQueryable<T> source, bool isTracked = false) where T : class
        {
            return isTracked ? source : source.AsNoTracking();
        }
    }
