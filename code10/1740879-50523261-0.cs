    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl =e.Row.FindControl("ddlMyDropDown") as DropDownList;
            if (ddl.Items.Count == 0)
            {
                ddl.Visible = false;
            }
            else
            {
                ddl.Visible = true;
            }
        }
    }
