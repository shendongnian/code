    public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
	{
		if(dTable == null)
			throw new ArgumentNullException(nameof(dTable));
		if(!dTable.Columns.Contains(colName))
			throw new ArgumentException($"Column {colName} doesn't exist in the table", nameof(colName));
		if (dTable.Rows.Count < 2)
			return dTable;
		
		IEnumerable<DataRow> duplicateRows = dTable.AsEnumerable()
			.GroupBy(r => r[colName])
			.SelectMany(g => g.OrderByDescending(r => r.Field<DateTime>("date")).Skip(1));
		foreach(DataRow duplicateRow in duplicateRows)
			dTable.Rows.Remove(duplicateRow);
		return dTable;
	}
