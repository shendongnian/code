	public IList<TReturn> GetValues<TEntity, TReturn>(IProjection column, Junction where, int top) where TEntity : BaseEntity
	{
		IQueryOver<TEntity> query = null;
		if(where == null)
			query = session.QueryOver<TEntity>().Select(column);
		else
			query = session.QueryOver<TEntity>().Select(column).Where(where);
		IList<TReturn> instance = null;
		if(top == 0)
			instance = query.List<TReturn>();
		else
			instance = query.Take(top).List<TReturn>();
		return instance;
	}
