    public IEnumerable<TModel> Get<TEntity, TModel>(
    	Expression<Func<TEntity, bool>> predicate, 
    	params Expression<Func<TEntity, object>>[] includes) 
    	where TEntity : class
    {
    	var result = _context.Set<TEntity>()
    		.Where(predicate);
    
        if(includes != null)
        {
        	foreach (var include in includes)
        	{
        		result = result.Include(include);
        	}
        }
    
    	return _mapper.Map<IList<TModel>>(result);
    }
