	public IEnumerable<TEntity> GetAllWithInclude(List<string> includes)
	{
		IQueryable<TEntity> entities = Context.Set<TEntity>();
		foreach (var include in includes)
		{
			entities = entities.Include(include);
		}
		return entities.ToList();
	} 
