	private static EqualityComparer<T> CreateComparer()
	{
		Type c = typeof(T);
		if (c == typeof(byte))
		{
			return (EqualityComparer<T>) new ByteEqualityComparer();
		}
		if (typeof(IEquatable<T>).IsAssignableFrom(c))
		{
			return (EqualityComparer<T>) typeof(GenericEqualityComparer<int>).TypeHandle.CreateInstanceForAnotherGenericParameter(c);
		}
		if (c.IsGenericType && (c.GetGenericTypeDefinition() == typeof(Nullable<>)))
		{
			Type type2 = c.GetGenericArguments()[0];
			if (typeof(IEquatable<>).MakeGenericType(new Type[] { type2 }).IsAssignableFrom(type2))
			{
				return (EqualityComparer<T>) typeof(NullableEqualityComparer<int>).TypeHandle.CreateInstanceForAnotherGenericParameter(type2);
			}
		}
		return new ObjectEqualityComparer<T>();
	}
