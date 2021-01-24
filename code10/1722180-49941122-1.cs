    public static Expression<Func<TFirstParam, TResult>>
        Compose<TFirstParam, TIntermediate, TResult>(
        this Expression<Func<TFirstParam, TIntermediate>> first,
        Expression<Func<TIntermediate, TResult>> second)
    {
        var param = Expression.Parameter(typeof(TFirstParam), "param");
    
        var newFirst = first.Body.Replace(first.Parameters[0], param);
        var newSecond = second.Body.Replace(second.Parameters[0], newFirst);
    
        return Expression.Lambda<Func<TFirstParam, TResult>>(newSecond, param);
    }
