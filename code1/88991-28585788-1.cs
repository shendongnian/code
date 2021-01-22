    public List<T> ConvertToList<T>(DataTable dt)
	{
		var columnNames = dt.Columns.Cast<DataColumn>()
			.Select(c => c.ColumnName)
			.ToList();
		var properties = typeof(T).GetProperties();
		return dt.AsEnumerable().Select(row =>
		{
			var objT = Activator.CreateInstance<T>();
			foreach (var pro in properties)
			{
				if (columnNames.Contains(pro.Name))
					pro.SetValue(objT, row[pro.Name]);
			}
			return objT;
		}).ToList();
	}
