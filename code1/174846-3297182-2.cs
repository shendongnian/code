    SuburbGridView.Rows.Cast<GridViewRow>().Where(
    	r => ((CheckBox)r.FindControl("SuburbSelector")).Checked).ToList().ForEach(row =>
    {
    	Response.Write(row.ID);
    	// Do something
    });
