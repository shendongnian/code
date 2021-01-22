    private void dgrdResults_MouseClick(object sender, MouseEventArgs e)
    {	
    	if (e.Button == System.Windows.Forms.MouseButtons.Right)
    	{                      
    		contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
    	}	
    }
    
    private void dgrdResults_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
    {
    	//handle the row selection on right click
    	if (e.Button == MouseButtons.Right)
    	{
    		try
    		{
    			dgrdResults.CurrentCell = dgrdResults.Rows[e.RowIndex].Cells[e.ColumnIndex];
    			// Can leave these here - doesn't hurt
    			dgrdResults.Rows[e.RowIndex].Selected = true;
    			dgrdResults.Focus();
    
    			selectedBiodataId = Convert.ToInt32(dgrdResults.Rows[e.RowIndex].Cells[1].Value);
    		}
    		catch (Exception)
    		{
    
    		}
    	}
    }
