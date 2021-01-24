    public static class QueryableUtils
    {
    	public static IQueryable<T> RemoveWhere<T>(this IQueryable<T> source)
    	{
    		var expression = new WhereRemover().Visit(source.Expression);
    		if (expression == source.Expression) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class WhereRemover : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			// Queryable.Where(source, predicate)
    			if (node.Method.DeclaringType == typeof(Queryable) && node.Method.Name == "Where")
    				return base.Visit(node.Arguments[0]); // source
    			return base.VisitMethodCall(node);
    		}
    	}
    }
