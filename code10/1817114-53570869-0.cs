	private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
	{
		if (e.Column is DataGridCheckBoxColumn dataGridCheckBoxColumn)
		{
			Binding binding = (Binding)dataGridCheckBoxColumn.Binding;
			binding.Converter = new BooleanToStringConverter(); //Converter Klaus Gütter mentioned
			e.Column = new DataGridTextColumn()
			{
				Header = dataGridCheckBoxColumn.Header,
				Binding = binding
			};
		}
	}
