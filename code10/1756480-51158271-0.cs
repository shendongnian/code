    //Note we need to make the entity and the model it maps to generic
    public IEnumerable<TModel> GetAll<TEntity, TModel>(
        params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
    {
    	var result = this.Set<TEntity>().AsQueryable();
    	
        if(includes != null)
        {
        	foreach (var include in includes)
        	{
        		result = result.Include(include);
        	}
        }
        return _mapper.Map<IList<TModel>>(result);
    }
