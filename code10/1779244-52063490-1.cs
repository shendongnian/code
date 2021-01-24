    public static partial class EfQueryableExtensions
    {
    	public static IQueryable<T> Parameterize<T>(this IQueryable<T> source)
    	{
    		var expression = new ContainsConverter().Visit(source.Expression);
    		if (expression == source) return source;
    		return source.Provider.CreateQuery<T>(expression);
    	}
    
    	class ContainsConverter : ExpressionVisitor
    	{
    		protected override Expression VisitMethodCall(MethodCallExpression node)
    		{
    			if (node.Method.DeclaringType == typeof(Enumerable) &&
    				node.Method.Name == nameof(Enumerable.Contains) &&
    				node.Arguments.Count == 2 &&
    				CanEvaluate(node.Arguments[0]))
    			{
    				var values = Expression.Lambda<Func<IEnumerable>>(node.Arguments[0]).Compile().Invoke();
    				var left = Visit(node.Arguments[1]);
    				Expression result = null;
    				foreach (var value in values)
    				{
    					// var variable = new Tuple<TValue>(value);
    					var variable = Activator.CreateInstance(typeof(Tuple<>).MakeGenericType(left.Type), value);
    					// var right = variable.Item1;
    					var right = Expression.Property(Expression.Constant(variable), nameof(Tuple<int>.Item1));
    					var match = Expression.Equal(left, right);
    					result = result != null ? Expression.OrElse(result, match) : match;
    				}
    				return result ?? Expression.Constant(false);
    			}
    			return base.VisitMethodCall(node);
    		}
    
    		static bool CanEvaluate(Expression e)
    		{
    			if (e == null) return true;
    			if (e.NodeType == ExpressionType.Convert)
    				return CanEvaluate(((UnaryExpression)e).Operand);
    			if (e.NodeType == ExpressionType.MemberAccess)
    				return CanEvaluate(((MemberExpression)e).Expression);
    			return e.NodeType == ExpressionType.Constant;
    		}
    	}
    }
