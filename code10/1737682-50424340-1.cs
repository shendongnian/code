    var query = (IQueryable)db.GetType().GetProperty(linkingTable).GetValue(db);
    // e =>
    var entity = Expression.Parameter(query.ElementType, "e");
    // ids.Contains(e.idField)
    // = Enumerable<int>.Contains(ids, e.idField)
    var containsCall = Expression.Call(
    	typeof(Enumerable),
    	nameof(Enumerable.Contains),
    	new Type[] { typeof(int) },
    	Expression.Constant(ids),
    	Expression.Property(entity, idField)
    );
    // e => ids.Contains(e.idField)
    var predicate = Expression.Lambda(containsCall, entity);
    // query = query.Where(predicate);
    query = Queryable.Where((dynamic)query, (dynamic)predicate);
