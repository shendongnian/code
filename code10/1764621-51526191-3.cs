    public static void AddQueryFilter<T>(this IMutableEntityType target, Expression<Func<T, bool>> filter)
    {
    	LambdaExpression targetFilter = filter;
    	if (target.ClrType != typeof(T))
    	{
    		var parameter = Expression.Parameter(target.ClrType, "e");
    		var body = filter.Body.ReplaceParameter(filter.Parameters[0], parameter);
    		targetFilter = Expression.Lambda(body, parameter);
    	}
    	target.AddQueryFilter(targetFilter);
    }
