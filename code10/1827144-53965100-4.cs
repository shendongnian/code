     public IQueryable<TEntity> ApplyIncludesOnQuery<TEntity>(IQueryable<TEntity> query,
        			params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : class, IEntity
        		{
        			// Return Applied Includes query
        			return (includeProperties.Aggregate(query, (current, include) => current.Include(include)));
        		}
