    public static IQueryable<TModel> WhereNotNull<TModel>(this IQueryable<TModel> query, string propertyName)
    {
        var parameter = Expression.Parameter(typeof(TModel), "x");
        var body = Expression.PropertyOrField(parameter, propertyName);
        Expression<Func<TModel, bool>> lambda = null;
        if (body.Type == typeof(string))
        {
            var methodCall = Expression.Call(typeof(string), nameof(string.IsNullOrWhiteSpace), null, body);
            var nullOrWhiteSpaceComparison = Expression.Not(methodCall);
            lambda = Expression.Lambda<Func<TModel, bool>>(nullOrWhiteSpaceComparison, parameter);
        }
        else
        {
            var nullComparison = Expression.NotEqual(body, Expression.Constant(null, typeof(object)));
            lambda = Expression.Lambda<Func<TModel, bool>>(nullComparison, parameter);
        }
        return query.Where(lambda);
        }
