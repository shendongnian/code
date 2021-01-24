    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.DataItemIndex > 0)
            {
                LinkButton lb = e.Row.Cells[0].Controls[0] as LinkButton;
                lb.Visible = false;
            }
        }
    }
