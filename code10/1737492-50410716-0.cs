    public static void RemoveEmptyColumns(this DataTable table, int columnStartIndex = 0)
	{
		for (int i = table.Columns.Count - 1; i >= columnStartIndex; i--)
		{
			DataColumn col = table.Columns[i];
			if (table.AsEnumerable().All(r => r.IsNull(col) || string.IsNullOrWhiteSpace(r[col].ToString())))
				table.Columns.RemoveAt(i);
		}
	}
