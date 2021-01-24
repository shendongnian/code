    public static DataTable ToDataTable<T>(this IList<T> items)
	{
		Type type = items.FirstOrDefault()?.GetType();
		if (type == null)
			throw new ArgumentException("The properties are derived from the first item, so the list must not be empty");
		DataTable dataTable = new DataTable(type.Name);
		//Get all the properties
		PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
		// ...
	}
