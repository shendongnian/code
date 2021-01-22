    void DataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
    	if (e.RowIndex >= 0 && e.ColumnIndex == ComboBoxColumnIndex)
    	{
    		ComboBox comboBox = this.DataGridView.Controls["ColumnComboBox" + e.RowIndex] as ComboBox;
    		if (comboBox == null)
    		{
    			comboBox = this.GetNewComboBox(e.RowIndex);
    			comboBox.Name = "ColumnComboBox" + e.RowIndex;
    			this.DataGridView.Controls.Add(comboBox);
    		}
    
    		if (comboBox != null)
    		{
    			comboBox.Width = e.CellBounds.Width - 10;
    			comboBox.Left = e.CellBounds.Left + ((e.CellBounds.Width - comboBox.Width) / 2);
    			comboBox.Top = e.CellBounds.Top + ((e.CellBounds.Height - comboBox.Height) / 2);
    		}
    	}
    }
