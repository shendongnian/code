	public List<SqlData> SqlDataBinding(List<SqlData> schema, List<dynamic> data)
	{
		foreach (SqlData item in schema)
		{
			item.Values = data[schema.IndexOf(item)];
		}
		return schema
	}
