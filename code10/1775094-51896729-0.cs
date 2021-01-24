    public static LambdaExpression GetNavigationPropertySelector(Type type, params string[] properties)
    {
    	return GetNavigationPropertySelector(type, properties, 0);
    }
    
    private static LambdaExpression GetNavigationPropertySelector(Type type, string[] properties, int depth)
    {
    	var parameter = Expression.Parameter(type, depth == 0 ? "x" : "x" + depth);
    	var body = GetNavigationPropertyExpression(parameter, properties, depth);
    	return Expression.Lambda(body, parameter);
    }
    
    private static Expression GetNavigationPropertyExpression(Expression source, string[] properties, int depth)
    {
    	if (depth >= properties.Length)
    		return source;
    	var property = Expression.Property(source, properties[depth]);
    	if (typeof(IEnumerable).IsAssignableFrom(property.Type))
    	{
    		var elementType = property.Type.GetGenericArguments()[0];
    		var elementSelector = GetNavigationPropertySelector(elementType, properties, depth + 1);
    		return Expression.Call(
    			typeof(Enumerable), "Select", new Type[] { elementType, elementSelector.Body.Type },
    			property, elementSelector);
    	}
    	else
    	{
    		return GetNavigationPropertyExpression(property, properties, depth + 1);
    	}
    }
