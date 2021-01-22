    private void TheGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (TheGrid.Columns[e.ColumnIndex].HeaderText == "Edit")
    	{
    		// to do: edit actions here
    		MessageBox.Show("Edit");
    	}
    }
