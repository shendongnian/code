    public static class FooFactory
	{
		private static readonly Dictionary<Type, Type> FooTypesLookup;
		static FooFactory()
		{
			FooTypesLookup = (from type in typeof(FooFactory).Assembly.GetExportedTypes()
							  let fooInterface =
								type.GetInterfaces().FirstOrDefault(
									x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IFoo<>))
							  where fooInterface != null
							  let firstTypeArgument = fooInterface.GetGenericArguments().First()
							  select new { Type = type, TypeArgument = firstTypeArgument })
				.ToDictionary(x => x.TypeArgument, x => x.Type);
		}
		public static IFoo<T> CreateFoo<T>()
		{
			var genericArgumentType = typeof(T);
			Type closedFooType;
			return FooTypesLookup.TryGetValue(genericArgumentType, out closedFooType)
			       	? (IFoo<T>) Activator.CreateInstance(closedFooType)
			       	: null;
		}
	}
