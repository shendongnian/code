	public static string DataTableToJSON(DataTable table)
	{
		var list = new List<Dictionary<string, object>>();
		
		foreach (DataRow row in table.Rows)
		{
			var dict = new Dictionary<string, object>();
			foreach (DataColumn col in table.Columns)
			{
				dict[col.ColumnName] = row[col];
			}
			list.Add(dict);
		}
		JavaScriptSerializer serializer = new JavaScriptSerializer();
		return serializer.Serialize(list);
	}
