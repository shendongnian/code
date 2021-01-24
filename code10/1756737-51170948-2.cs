    public static Expression<Func<TSource, bool>> SearchMethod<TSource>(SearchDetails searchDetails)
    {
        ParameterExpression par = Expression.Parameter(typeof(TSource), "x");
        var col = Expression.Property(par, searchDetails.ColName);
        Expression body = Expression.Call(col, "Contains", null, Expression.Constant(searchDetails.SearchVal));
        var lambda = Expression.Lambda<Func<TSource, bool>>(body, par);
        return lambda;
    }
