    protected void gvCSMeasureCompare_RowDataBound(object sender, GridViewRowEventArgs e)
    		{
    			if (e.Row.RowType == DataControlRowType.Header)
    				e.Row.Cells[0].Text = "New Header for Column 1";
    }
