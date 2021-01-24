    public static DataTable RemoveDuplicateRows(DataTable dTable, string colName)
	{
		if(dTable == null)
			throw new ArgumentNullException(nameof(dTable));
		if(!dTable.Columns.Contains(colName))
			throw new ArgumentException($"Column {colName} doesn't exist in the table", nameof(colName));
		if (dTable.Rows.Count < 2)
			return dTable;
       List<DataRow> duplicateRows = dTable.AsEnumerable()
		.GroupBy(r => r[colName])
		.SelectMany(g => g
			.Select(r => new
			{
				Row = r,
				Date = DateTime.TryParse(r.Field<string>("date"), out DateTime date) ? date : new DateTime?()
			})
			.OrderByDescending(x => x.Date.HasValue)
			.ThenByDescending(x => x.Date.GetValueOrDefault())
			.Skip(1))  // only the first row of the group will be retained
		.Select(x => x.Row)
        .ToList();
        duplicateRows.ForEach(dTable.Rows.Remove);
		return dTable;
	}
