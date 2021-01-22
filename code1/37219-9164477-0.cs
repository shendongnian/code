        private static MethodInfo GetMethod<T>(Expression<Func<T>> expression)
		{
			return ((MethodCallExpression)expression.Body).Method;
		}
		public static void CallSelect()
		{
			MethodInfo definition = GetMethod(() => Enumerable.Select(null, (Func<object, object>)null)).GetGenericMethodDefinition();
			definition.MakeGenericMethod(typeof(int), typeof(int)).Invoke(null, new object[] { new List<int>(), ((Func<int, int>)(x => x)) });
		}
