    static class Extensions
    {
        public static TResult MaxOrDefault<T, TResult>(this IQueryable<T> source, 
                                                       Expression<Func<T, TResult>> selector)
            where TResult : struct
        {
            UnaryExpression castedBody = Expression.Convert(selector.Body, typeof(TResult?));
            Expression<Func<T, TResult?>> lambda = Expression.Lambda<Func<T,TResult?>>(castedBody, selector.Parameters);
            return source.Max(lambda) ?? default(TResult);
        }
    }
