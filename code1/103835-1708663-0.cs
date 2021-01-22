    private void dgColorCodeKey_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {  
    	if (e.RowIndex >= 0)
    	{
    	    //if we are binding a cell in the Color column
    	    if (e.ColumnIndex == colColor.Index)
    	    {
    	    	//ColorCode is a custom object that contains the name of a System.Drawing.Color
    		ColorCode bindingObject = (ColorCode)dgColorCodeKey.Rows[e.RowIndex].DataBoundItem;
    		dgColorCodeKey[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.FromName(bindingObject.Color);
    		
    		//set this property to true to tell the datagrid that we've applied our own formatting
    		e.FormattingApplied = true;
    	    }
    	}
    }
