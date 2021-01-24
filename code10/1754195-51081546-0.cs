	private void DataGrid_OnPreviewMouseMove(object sender, MouseEventArgs e)
	{
		var dataGrid = (DataGrid)sender;
		var inputElement = dataGrid.InputHitTest(e.GetPosition(dataGrid)); // Get the element under mouse pointer
		var cell = ((Visual)inputElement).GetAncestorOfType<DataGridCell>(); // Get the parent DataGridCell element
		if (cell == null)
			return; // Only interested in cells
		var column = cell.Column; // Simple...
		if (column is DataGridComboBoxColumn comboColumn)
			; // This is a combo box column
	}
