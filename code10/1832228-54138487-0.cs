    var orderByList = new List<Expression<Func<TEntity, int>>>();
    Expression<Func<TEntity,int>> orderBy1 = x => x.A;
    Expression<Func<TEntity, int>> orderBy2 = x => x.B;
    Expression<Func<TEntity, int>> orderBy3 = x => x.C;
    orderByList.Add(orderBy1);
    orderByList.Add(orderBy2);
    orderByList.Add(orderBy3);
    
    var resultOrderedQueryable =
    	orderByList.Aggregate<Expression<Func<TEntity, int>>, IOrderedQueryable<TEntity>>(null, (current, orderBy) => current?.ThenBy(x => x.Id) ?? query.OrderBy(orderBy));
