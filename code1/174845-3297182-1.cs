    SuburbGridView.Rows.Cast<GridViewRow>().Where(
        r => ((CheckBox)r.FindControl("SuburbSelector")).Checked).AsParallel().ForAll(row =>
    {
    	Response.Write(row.ID);
    	// Do something
    });
