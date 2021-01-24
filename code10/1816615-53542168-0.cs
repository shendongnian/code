    public static DataTable ToDataTable<T>(this IList<T> items)
	{
		Type type = items.FirstOrDefault()?.GetType();
		if (type == null)
			type = typeof(T);
		DataTable dataTable = new DataTable(type.Name);
		//Get all the properties
		PropertyInfo[] Props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
		// ...
	}
