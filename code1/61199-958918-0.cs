    public static class QueryableExtensions
    {
        public static IQueryable<T> Page(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            int skipCount = (pageNumber-1) * pageSize;
            query = query.Skip(skipCount);
            query = query.Take(pageSize);
            return query;
        }
    }
