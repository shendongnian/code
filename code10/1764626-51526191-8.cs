    public static void AddQueryFilter(this IMutableEntityType target, LambdaExpression filter)
    {
    	if (target.QueryFilter == null)
    		target.QueryFilter = filter;
    	else
    	{
    		var parameter = target.QueryFilter.Parameters[0];
    		var left = target.QueryFilter.Body;
    		var right = filter.Body.ReplaceParameter(filter.Parameters[0], parameter);
    		var body = Expression.AndAlso(left, right);
    		target.QueryFilter = Expression.Lambda(body, parameter);
    	}
    }
