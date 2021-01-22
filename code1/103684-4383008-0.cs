    var columns = new DataGridColumnCollection(true, dataGrid);
			for (int i = 0; i < pivotTable.DetailsColumnCount; i++)
			{
				if (!pivotTable.NullColumns.Contains(i))
				{
					columns.Add(new PivotDetailColumn(pivotTable, i));
				}
			}
			columns.ForceUpdate();
			dataGrid.Columns = columns;
			dataGrid.ItemsSource =
				Enumerable.Range(0, pivotTable.DetailsRowCount)
					.Where(i => !pivotTable.NullRows.Contains(i)) // Only non null rows
					.ToList();
