        static void Main(string[] args)
		{
			var converted = NullCoalesce((MethodInfo p) => p.DeclaringType.Assembly.Evidence.Locked);
			var converted2 = NullCoalesce((string[] s) => s.Length);
		}
		private static Expression<Func<TSource, TResult>> NullCoalesce<TSource, TResult>(Expression<Func<TSource, TResult>> lambdaExpression)
		{
			var test = GetTest(lambdaExpression.Body);
			if (test != null)
			{
				return Expression.Lambda<Func<TSource, TResult>>(
					Expression.Condition(
						test,
						lambdaExpression.Body,
						Expression.Default(
							typeof(TResult)
						)
					),
					lambdaExpression.Parameters
				);
			}
			return lambdaExpression;
		}
		private static Expression GetTest(Expression expression)
		{
			Expression container;
			switch (expression.NodeType)
			{
				case ExpressionType.ArrayLength:
					container = ((UnaryExpression)expression).Operand;
					break;
				case ExpressionType.MemberAccess:
					if ((container = ((MemberExpression)expression).Expression) == null)
					{
						return null;
					}
					break;
				default:
					return null;
			}
			var baseTest = GetTest(container);
			if (!container.Type.IsValueType)
			{
				var containerNotNull = Expression.NotEqual(
					container,
					Expression.Default(
						container.Type
					)
				);
				return (baseTest == null ?
					containerNotNull :
					Expression.AndAlso(
						baseTest,
						containerNotNull
					)
				);
			}
			return baseTest;
		}
