    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        if (e.Row.RowType != DataControlRowType.Header)
        		return;
    
        // let the third column span over the next 2 columns.
        e.Row.Cells[2].ColumnSpan = 3;
        e.Row.Cells[3].Visible = false;
        e.Row.Cells[4].Visible = false;
        	
        // could span more than 1 row.
        e.Row.Cells[2].RowSpan = 2;
