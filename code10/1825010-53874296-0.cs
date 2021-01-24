    private static Expression GetLocalizedString(Expression stringExpression, SupportedCulture supportedCulture)
    {
    	var expression = Expression.Parameter(typeof(APILocalizedString), nameof(APILocalizedString));
    
    	var prop = Expression.Property(expression, nameof(APILocalizedString.SupportedCulture));
    	var value = Expression.Constant(supportedCulture);
    	var condition = Expression.Equal(prop, value);
    
    	var where = Expression.Call(
    		typeof(Enumerable),
    		nameof(Enumerable.Where),
    		new Type[] { typeof(APILocalizedString) },
    		stringExpression,
    		Expression.Lambda<Func<APILocalizedString, bool>>(condition, expression));
    
    	var first = Expression.Call(
    		typeof(Enumerable),
    		nameof(Enumerable.First),
    		new Type[] { typeof(APILocalizedString) },
    		stringExpression);
    
    	var defaultIfEmpty = Expression.Call(
    		typeof(Enumerable),
    		nameof(Enumerable.DefaultIfEmpty),
    		new Type[] { typeof(APILocalizedString) },
    		where,
    		first);
    
    	var select = Expression.Call(
    		typeof(Enumerable),
    		nameof(Enumerable.Select),
    		new Type[] { typeof(APILocalizedString), typeof(string) },
    		defaultIfEmpty,
    		Expression.Lambda<Func<APILocalizedString, string>>(
    			Expression.Property(expression, nameof(APILocalizedString.Text)),
    			expression
    		));
    
    	var firstOrDefault =
    		Expression.Call(
    		typeof(Enumerable),
    		nameof(Enumerable.FirstOrDefault),
    		new Type[] { typeof(string) },
    		select);
    
    
    	var nullCheck = Expression.Equal(stringExpression, Expression.Constant(null, stringExpression.Type));
    	var result = Expression.Condition(nullCheck, Expression.Constant(""), firstOrDefault);
    
    	return result;
    }
  
