    if (e.Row.RowType == DataControlRowType.DataRow)
    {
    
        if ((e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            //find the items in the edit row
            var DropDownList3 = e.Row.FindControl("DropDownList3") as DropDownList;
    
            DropDownList3.DataSource = dt;
            DropDownList3.DataTextField = "status";
            DropDownList3.DataValueField = "status";
            DropDownList3.DataBind();
        }
        else
        {
            //every other row
            var Label2 = e.Row.FindControl("Label2") as Label;
    
            Label2.Text = "Label 2 found";
        }
    }
