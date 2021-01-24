    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddl = e.Row.FindControl("") as DropDownList;
            ddl.DataSource = LoadDataFromDB("select a from b order by c");
            ddl.DataTextField = "username";
            ddl.DataValueField = "fullwidth";
            ddl.DataBind();
        }
    }
