    // Step 1: Add all columns from your two DataTables to dtRtn
	DataTable dtRtn = new DataTable();
	CopyColumns(dtFormData, dtRtn, "FormData.");
	CopyColumns(dtResponderDetails, dtRtn, "ResponderDetails.");
	
	foreach(var row in result) {
        // Step 2: Build a collection of all the values for this result
		var targetRow = new List<object>();
		PopulateRows(dtFormData, row.d1, targetRow);
		PopulateRows(dtResponderDetails, row.d2, targetRow);
        // Pass the values in as an array, while will convert it to a new DataRow
		dtRtn.Rows.Add(targetRow.ToArray());
	}
    //...
	private void CopyColumns(DataTable sourceTable, DataTable targetTable, string rowPrefix)
	{
		foreach (DataColumn column in sourceTable.Columns)
		{
            // Add each column from your source tables to the new aggregate table,
            // adding a prefix to avoid any naming collisions
			var rowName = String.Format("{0}{1}", rowPrefix, column.ColumnName);
			targetTable.Columns.Add(rowName, column.DataType);
		}
	}
	
	private void PopulateRows(DataTable table, DataRow sourceRow, List<object> targetRow)
	{
		for(var i = 0; i < table.Columns.Count; i++) {
			targetRow.Add(sourceRow[i]);
		}
	}
