    public List<TEntity> GetAll<TEntity>() 
        where TEntity : class //This is important as the Set method requires it
    {
        //Obviously don't do this, but for completeness:
        var dbContext = new MyContext();
        //And here is the real 'magic':
    	return dbContext.Set<TEntity>().ToList();
    }
