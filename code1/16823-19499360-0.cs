		#region Count
		/// <summary>
		/// gets the 
		/// public static int Count&lt;TSource>(this IEnumerable&lt;TSource> source);
		/// methodinfo
		/// </summary>
		/// <typeparam name="TSource">type of the elements</typeparam>
		/// <returns></returns>
		public static MethodInfo GetCountMethod<TSource>()
		{
			Expression<Func<IEnumerable<TSource>, int>> lamda = list => list.Count();
			return (lamda.Body as MethodCallExpression).Method;
		}
		/// <summary>
		/// gets the 
		/// public static int Count&lt;TSource>(this IEnumerable&lt;TSource> source);
		/// methodinfo
		/// </summary>
		/// <param name="elementType">type of the elements</param>
		/// <returns></returns>
		public static MethodInfo GetCountMethodByType(Type elementType)
		{
			// to get the method name, we use lambdas too
			Expression<Action> methodNamer = () => GetCountMethod<object>();
			var gmi = ((MethodCallExpression)methodNamer.Body).Method.GetGenericMethodDefinition();
			var mi = gmi.MakeGenericMethod(new Type[] { elementType });
			return mi.Invoke(null, new object[] { }) as MethodInfo;
		}
		#endregion Disctinct
