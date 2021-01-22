    private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    	if (e.ColumnIndex == "Here checkbox column id or name") {
    		DGV.Item(e.ColumnIndex, e.RowIndex + 1).Selected = true;
    		//Here your code
    		
    	}
    }
