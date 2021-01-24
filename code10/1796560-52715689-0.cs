    public static class QueryExtensions
    {
        public static IQueryable<TModel> WhereNotNull<TModel, TProperty>(this IQueryable<TModel> query, Func<TModel, TProperty> propertySelector)
        {
            return query.Where(a => propertySelector(a) != null);
        }
    }
