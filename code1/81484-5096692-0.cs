        using System.Windows;
        using System.Linq.Expressions;
        using Expression = System.Linq.Expressions.Expression;
		static void Main(string[] args)
		{
			Func<WeakEventManager, bool> cleanUpFunction = BuildCleanUpFunction();
		}
		private static Func<WeakEventManager, bool> BuildCleanUpFunction()
		{
			ParameterExpression managerParameter = Expression.Parameter(
				typeof(WeakEventManager),
				"manager"
			);
			return Expression.Lambda<Func<WeakEventManager, bool>>(
				Expression.Call(
					Expression.Property(
						managerParameter,
						"Table"
					),
					"Purge",
					Type.EmptyTypes,
					Expression.Default(
						typeof(bool)
					)
				),
				managerParameter
			).Compile();
		}
