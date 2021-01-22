    public static class SortingUtilities<T, TProperty>
    {
        public static IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> query, Expression<Func<T, TProperty>> selector)
        {
            return query.OrderBy(selector);
        }
        public static IOrderedQueryable<T> ApplyOrderByDescending(IQueryable<T> query, Expression<Func<T, TProperty>> selector)
        {
            return query.OrderByDescending(selector);
        }
        public static IQueryable<T> Preload(IQueryable<T> query, Expression<Func<T, TProperty>> selector)
        {
            return query.Include(selector);
        }
    }
