    // Step 1: Add all columns from your two DataTables to dtRtn
    // (with a prefix to avoid naming collisions)
	DataTable dtRtn = new DataTable();
	CopyColumns(dtFormData, dtRtn, "FormData.");
	CopyColumns(dtResponderDetails, dtRtn, "ResponderDetails.");
	
    // Step 2: Build a collection containing all of the values for this result
	var numFormColumns = dtFormData.Columns.Count;
	var numResponderColumns = dtResponderDetails.Columns.Count;
	foreach(var row in result) {
		var targetRow = new List<object>();
		PopulateRows(row.d1, numFormColumns, targetRow);
		PopulateRows(row.d2, numResponderColumns, targetRow);
        // Pass the values in as an array, which will convert it to a new DataRow
		dtRtn.Rows.Add(targetRow.ToArray());
	}
    //...
	private void CopyColumns(DataTable sourceTable, DataTable targetTable, string rowPrefix)
	{
		foreach (DataColumn column in sourceTable.Columns)
		{
			var rowName = String.Format("{0}{1}", rowPrefix, column.ColumnName);
			targetTable.Columns.Add(rowName, column.DataType);
		}
	}
	
	void PopulateRows(DataRow sourceRow, int numColumns, List<object> targetRow)
	{
		for(var i = 0; i < numColumns; i++) {
			targetRow.Add(sourceRow[i]);
		}
	}
