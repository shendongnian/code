    MethodCallExpression whereCallExpression = Expression.Call(
    	typeof(Queryable),
    	"Where",
    	new Type[] { queryableData.ElementType },
    	queryableData.Expression,
    	predicate);
    
    IQueryable<TSource> resultsQuery =  
        queryableData.Provider.CreateQuery<TSource>(whereCallExpression);
