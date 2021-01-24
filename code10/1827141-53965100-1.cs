     protected internal IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        		{
        			// Declare 'query' and set it by calling 'RetrieveQuery' method
        			var query = RetrieveQuery();
        
        			// Apply 'predicate'
        			if (predicate != null)
        			{
        				query = query.Where(predicate).AsQueryable();
        			}
        
        			// Apply Includes
        			if (includeProperties != null)
        			{
        				query = _queryableUnitOfWork.ApplyIncludesOnQuery(query, includeProperties);
        			}
        
        			// Return 'query'
        			return (query);
        		}
    
