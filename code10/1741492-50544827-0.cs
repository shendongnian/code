    private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
    	if (GetColumnHeader(dataGridView1, e.ColumnIndex) == "ColumnToCheckName" && e.RowIndex != -1)
    	{
    		using (var cbx = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells["ColumnCellName"])
    		{
    			try
    			{
    				// Do something with value .... cbx.Value 
    			}
    			catch
    			{ }
    		}
    	}
    }
