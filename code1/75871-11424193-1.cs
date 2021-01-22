	// Create the list of columns
	String[] szColumns = new String[data.Columns.Count];
	for (int index = 0; index < data.Columns.Count; index++)
	{
		szColumns[index] = data.Columns[index].ColumnName;
	}
	// Get the distinct records
	data = data.DefaultView.ToTable(true, szColumns);
