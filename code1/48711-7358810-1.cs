	public static IQueryable<TResult> Transform<TResult>(this IQueryable source)
	{
		var resultType = typeof(TResult);
		var resultProperties = resultType.GetProperties().Where(p => p.CanWrite);
		ParameterExpression s = Expression.Parameter(source.ElementType, "s");
		var memberBindings =
			resultProperties.Select(p =>
				Expression.Bind(typeof(TResult).GetMember(p.Name)[0], Expression.Property(s, p.Name))).OfType<MemberBinding>();
		Expression memberInit = Expression.MemberInit(
			Expression.New(typeof(TResult)),
			memberBindings
			);
		var memberInitLambda = Expression.Lambda(memberInit, s);
		var typeArgs = new[]
			{
				source.ElementType, 
				memberInit.Type
			};
		var mc = Expression.Call(typeof(Queryable), "Select", typeArgs, source.Expression, memberInitLambda);
		
		var query = source.Provider.CreateQuery<TResult>(mc);
		return query;
	}
	public static IEnumerable<TResult> Transform<TResult>(this IEnumerable source)
	{
		return source.AsQueryable().Transform<TResult>();
	}
