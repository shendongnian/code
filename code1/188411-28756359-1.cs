	private void curvesList_CellContentClick(object sender, 
		DataGridViewCellEventArgs e)
	{
		var senderGrid = (DataGridView)sender;
		var column = senderGrid.Columns[e.ColumnIndex];
		if (e.RowIndex >= 0)
		{
			if ((object)column == (object)color)
			{
				colorDialog.Color = Color.Blue;
					colorDialog.ShowDialog();
			}
		}
	}
