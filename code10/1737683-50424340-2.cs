    // query.Where(predicate)
    // = Queryable.Where<ElementType>(query, predicate)
    var whereCall = Expression.Call(
    	typeof(Queryable),
    	nameof(Queryable.Where),
    	new Type[] { query.ElementType },
    	query.Expression,
    	predicate
    );
    // query = query.Where(predicate)
    query = query.Provider.CreateQuery(whereCall);
