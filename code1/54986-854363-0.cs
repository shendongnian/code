	DataTable oldTable = new DataTable();
	...
	DataTable newTable = new DataTable();
	newTable.Columns.Add("Field Name");
	for (int i = 0; i < oldTable.Rows.Count; i++)
		newTable.Columns.Add();
	for (int i = 0; i < oldTable.Columns.Count; i++)
	{
		DataRow newRow = newTable.NewRow();
		newRow[0] = oldTable.Columns[i].Caption;
		for (int j = 0; j < oldTable.Rows.Count; j++)
			newRow[j+1] = oldTable.Rows[j][i];
		newTable.Rows.Add(newRow);
	}
	dataGridView.DataSource = newTable;
