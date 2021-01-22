	private void InsertDataGridRow(DataGrid dataGrid, int index, TableCell tc)
	{
		DataGridItem di = new DataGridItem(index, 0, ListItemType.Item);
		// Check which columns are visible
		bool foundFirstVisibleColumn = false;
		int numberOfVisibleColumns = 0;
		foreach (DataGridColumn column in dataGrid.Columns)
		{
			if (column.Visible == true)
			{
				numberOfVisibleColumns++;
				foundFirstVisibleColumn = true;
			}
			// Add dummy columns in the columns that are hidden
			if (!foundFirstVisibleColumn)
			{
				di.Cells.Add(new TableCell());
			}
		}
		tc.ColumnSpan = numberOfVisibleColumns;
		di.Cells.Add(tc);
		Table t = (Table)dataGrid.Controls[0];
		t.Rows.Add(di);
	}
