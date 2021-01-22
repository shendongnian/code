    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.Header)
    {
    DropDownList ddlLocation = (DropDownList)e.Row.FindControl("ddlLocation");
    ddlLocation.DataSource = dtLocation;
    ddlLocation.DataBind();
    }
    }
    }
