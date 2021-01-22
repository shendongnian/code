    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onclick", "javascript:__doPostBack('grid','Select$" + e.Row.RowIndex + "')");
        }
    }
    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl.Text = "changed...";
    }
