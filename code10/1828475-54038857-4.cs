    public static class MyQueryableExtensions
    {
        public static IQueryable<T> In<T, TProp>(this IQueryable<T> source,
            Expression<Func<T, TProp>> propSelector, IEnumerable<TProp> values)
        {
            var @params = propSelector.Parameters;
            var propAcc = propSelector.Body;
            Expression body = Expression.Constant(false, typeof(bool));
            foreach (var v in values)
                body = Expression.OrElse(body,
                    Expression.Equal(propAcc,
                        Expression.Constant(v, typeof(TProp))));
            var lambda = Expression.Lambda<Func<T, bool>>(body, @params);
            return source.Where(lambda);
        }
    }
