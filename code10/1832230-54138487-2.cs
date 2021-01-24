       var orderByList = new List<Expression<Func<TEntity, object>>>();
    			Expression<Func<TEntity,object>> orderBy1 = x => x.Id;
    			Expression<Func<TEntity, object>> orderBy2 = x => x.ToString();
    			Expression<Func<TEntity, object>> orderBy3 = x => x.Id;
    			orderByList.Add(orderBy1);
    			orderByList.Add(orderBy2);
    			orderByList.Add(orderBy3);
    
    			var resultOrderedQueryable = orderByList.Aggregate<Expression<Func<TEntity, object>>, IOrderedQueryable<TEntity>>(null, (current, orderBy) => current != null ? current.ThenBy(orderBy) : query.OrderBy(orderBy));
