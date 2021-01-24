    public static class QueryExtensions
    {
        public static IQueryable<TModel> WhereNotNull<TModel>(this IQueryable<TModel> query, string propertyName)
        {
            var parameter = Expression.Parameter(typeof(TModel), "x");
            var body = Expression.PropertyOrField(parameter, propertyName);
            var comparison = Expression.NotEqual(body, Expression.Constant(null, typeof(object)));
            var lambda = Expression.Lambda<Func<TModel, bool>>(comparison, parameter);
            return query.Where(lambda);
        }
    }
