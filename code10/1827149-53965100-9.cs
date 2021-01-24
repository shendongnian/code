    protected internal IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
	{
		var query = RetrieveQuery();
		if (predicate != null)
		{
			query = query.Where(predicate).AsQueryable();
		}
		if (includeProperties != null)
		{
			query = _queryableUnitOfWork.ApplyIncludesOnQuery(query, includeProperties);
		}
		return (query);
	}
    
