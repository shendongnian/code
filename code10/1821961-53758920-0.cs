    DataTable aggrTable = new DataTable();
	aggrTable.Columns.Add(columnToGroup);
	var aggrColumns = tbl.Columns.Cast<DataColumn>()
		.Where(c => !c.ColumnName.Equals(columnToGroup, StringComparison.InvariantCultureIgnoreCase));
	foreach (DataColumn col in aggrColumns)
		aggrTable.Columns.Add(col.ColumnName, typeof(int));
	var grpQuery = tbl.AsEnumerable().GroupBy(r => r[columnToGroup]);
	foreach (var grp in grpQuery)
	{
		DataRow row = aggrTable.Rows.Add();
		row[columnToGroup] = grp.Key;
		foreach (DataColumn col in aggrColumns)
			row[col.ColumnName] = grp.Count(r => !r.IsNull(col.ColumnName));
	}
