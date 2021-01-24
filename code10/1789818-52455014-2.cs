    internal static Expression<Func<TEntity, bool>> CreateTypeSpesificExpression<TEntity>(string refName) where TEntity : class
	{
		var parameter = Expression.Parameter(typeof(IAmObject));
		var member = Expression.Property(parameter, nameof(IAmObject.GrefType));
		var contant = Expression.Constant(refName);
		var body = Expression.Equal(member, contant);
		var extra = Expression.Lambda<Func<TEntity, bool>>(body, parameter);
		return extra;
	}
