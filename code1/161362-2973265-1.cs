    enum Whatever { Ready, Set, Go }
	public static string GetEnumerationString(Enum enumeration)
	{
		string resourceName = 
			string.Concat(enumeration.GetType().Name, "_", enumeration);
		return GetString(resourceName);
	}
