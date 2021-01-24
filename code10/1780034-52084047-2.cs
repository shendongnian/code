    public static Expression<Func<T, bool>> OrAll<T>(IEnumerable<Expression<Func<T, bool>>> predicates)
    {
        var parameter = Expression.Parameter(typeof(T));
        var newBody = predicates.Select(predicate => predicate.Body.ReplaceParameter(predicate.Parameters[0], parameter))
            .DefaultIfEmpty(Expression.Constant(false))
            .Aggregate((a, b) => Expression.OrElse(a, b));
        return Expression.Lambda<Func<T, bool>>(newBody, parameter);
    }
