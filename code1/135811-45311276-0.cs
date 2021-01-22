	public static class TypeNameGetter
	{
		public static string GetTypeName<T>()
		{
			return typeof( T ).Name;
		}
	}
