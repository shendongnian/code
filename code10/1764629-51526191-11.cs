    public static EntityTypeBuilder<TEntity> AddQueryFilter<TEntity>(this EntityTypeBuilder<TEntity> target, Expression<Func<TEntity, bool>> filter)
    	where TEntity : class
    {
    	target.Metadata.AddQueryFilter(filter);
    	return target;
    }
