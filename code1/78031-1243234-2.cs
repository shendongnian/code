    protected void gvSearch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList d = (DropDownList)e.Row.FindControl("ddlFields");
            string type = ((HiddenField)e.Row.FindControl("hfFieldType")).Value;
            _type = type;
            d.DataBind();
        }
    }
    protected void odsOperator_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {
        e.InputParameters["Type"] = _type;
    }
    private string _type = "";
