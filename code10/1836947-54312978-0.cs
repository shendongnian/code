    public static class CustomQueryableExtensions
    {
        public static IQueryable<IGrouping<INamed, T>> GroupByNamed<T>(this IQueryable<T> query, BillGroup group)
        {
            //enum name must be the same as property name
            string property = group.ToString();
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            Expression prop = Expression.Property(parameter, property);
            var lambda = Expression.Lambda<Func<T, INamed>>(prop, parameter);
            return query.GroupBy(lambda);
        }
    }
