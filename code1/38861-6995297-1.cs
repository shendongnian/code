    protected void ObjectDataSource1__RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                 DropDownList typeFilter = (DropDownList)GridView1.FindControl("TypeFilter");
            }
         }
