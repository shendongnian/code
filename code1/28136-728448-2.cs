    public static class EnumerableMinusWTF
	{
		public static IEnumerable<TResult> Cast<TResult,TSource>(this IEnumerable<TSource> source)
		{
			Type source_type = typeof(TSource);
			Type target_type = typeof(TResult);
			List<MethodInfo> methods = new List<MethodInfo>();
			methods.AddRange( target_type.GetMethods( BindingFlags.Static | BindingFlags.Public ) ); //target methods will be favored in the search
			methods.AddRange( source_type.GetMethods( BindingFlags.Static | BindingFlags.Public ) );
			MethodInfo op_Explicit = FindExplicitConverstion(source_type, target_type, methods );
			List<TResult> results = new List<TResult>();
			foreach (TSource source_item in source)
				results.Add((TResult)op_Explicit.Invoke(null, new object[] { source_item }));
			return results;
		}
		public static MethodInfo FindExplicitConverstion(Type source_type, Type target_type, List<MethodInfo> methods)
		{
			foreach (MethodInfo mi in methods)
			{
				if (mi.Name == "op_Explicit") //will return target and take one parameter
					if (mi.ReturnType == target_type)
						if (mi.GetParameters()[0].ParameterType == source_type)
							return mi;
			}
			throw new InvalidCastException( "Could not find conversion operator to convert " + source_type.FullName + " to " + target_type.FullName + "." );
		}
	}
