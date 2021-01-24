    private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	Trace.WriteLine("Cell Content Click Col: " + e.ColumnIndex + " Row: " + e.RowIndex);
    
    	if (e.ColumnIndex == 0)
    	{
    		DataGridViewCheckBoxCell cell = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewCheckBoxCell;
    		if (cell != null)
    		{
    			Trace.WriteLine("Value:" + cell.EditingCellFormattedValue);
    		}
    	}
    }
