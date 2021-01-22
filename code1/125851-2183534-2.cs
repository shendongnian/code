    protected void theGrid_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        var data = e.DataItem as DataRowView;
        if (data != null)
        {
            if (data.Row.IsNull("foo")) e.Row.Cells[0] = "-";
            if (data.Row.IsNull("bar")) e.Row.Cells[0] = "-";
        }
    }
