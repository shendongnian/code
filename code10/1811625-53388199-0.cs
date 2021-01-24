	public IList<TEntity> GetList<TEntity>(ProjectionList columnList, Junction where, int top) where TEntity : BaseEntity
	{
		IQueryOver<TEntity> query = null;
		if((columnList != null) && (where != null))
		{
			query = session.QueryOver<TEntity>()
					.Select(columnList)
					.TransformUsing(Transformers.AliasToBean<TEntity>())
					.Where(where);
		}
		else if((columnList != null) && (where == null))
		{
			query = session.QueryOver<TEntity>()
					.Select(columnList)
					.TransformUsing(Transformers.AliasToBean<TEntity>());
		}
		else if((columnList == null) && (where != null))
		{
			query = session.QueryOver<TEntity>()
					.Where(where);
		}
		else
		{
			query = session.QueryOver<TEntity>();
		}
		IList<TEntity> result = query.Take(top).List();
		return result;
	}
