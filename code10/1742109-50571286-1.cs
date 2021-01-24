    protected void GridViewActivities_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                lb.Attributes.Add("onclick", "confirm('You are sure?'); MyFunction(); return true; ");
            }
        }
    
