    public static class QueryableExtensions
    {
        public static IQueryable AsMaybeTracking(IQueryable source, bool isTracked = false)
        {
            return isTracked ? source : source.AsNoTracking();
        }
    }
