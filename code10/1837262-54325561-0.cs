    protected void gvCursisten_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            ComboBox cb = (e.Row.FindControl("gvcomboboxid") as ComboBox);
            if(some_value == null)
            {
                cb.Visible = false;
            }
            else
            {
                cb.Visible = true;
            }
        }
    }
