	// Temporarily holds the value of a cell in the DataGridView once a cell has begun to be edited.
	// The value in this variable is then compared to the value of the cell after the edit is complete to see if the data chagned before updating the controlParameters object
	object CellValue;
	private void MyDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
	{
		// Set this variable to the current cell's value to compare later to see if it's contents have changed
		this.CellValue = MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
	}
	
	private void MyDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
	{
		// Exit this event procedure if no rows have been added to the DataGridView yet (during program initialization)
		if (e.RowIndex < 0)
		{
			return;
		}
		// Proceed only if the value in the current cell has been changed since it went into edit mode
		if (this.CellValue != MyDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value)
		{
			// Do your cell data manipulation here
		}
	}
