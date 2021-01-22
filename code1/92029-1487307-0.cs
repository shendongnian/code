	void Add(ColumnViewModel columnViewModel)
	{
		var column = new DataGridTextColumn
		{
			Header = columnViewModel.Name,
			Binding = new Binding("[" + columnViewModel.Name + "]")
		};
		dataGrid.Columns.Add(column);
	}
