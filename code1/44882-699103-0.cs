    protected void gvMaster_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) {
            GridView gv = (GridView)e.Row.FindControl("gvDetails");
        }
    }
