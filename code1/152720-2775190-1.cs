    var param = Expression.Parameter(filterType, propertyName);
    var left = Expression.Property(param, filterType.GetProperty(propertyName));
    var right = Expression.Constant(propertyValue, modelMetaData.ModelType);
    
    LambdaExpression predicate = null;
    
    if (searchFilterAttribute.FilterType == FilterType.Contains)
    {
    	var methodContains = typeof(string).GetMethod("Contains", new[] { typeof(string) });
    	var filterContains = Expression.Call(left, methodContains, right);
    	predicate = Expression.Lambda(filterContains, param);
    }
    else
    {
    	var expr = Expression.Equal(left, right);
    	predicate = Expression.Lambda(expr, param);
    
    }
    
    var expression = Expression.Call(
    	typeof(Queryable), 
    	"Where", 
    	new Type[] { queryable.ElementType },
    	queryable.Expression,
    	predicate);
    
    queryable = queryable.Provider.CreateQuery<T>(expression);
