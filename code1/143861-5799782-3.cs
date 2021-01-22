    protected void GV1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if(e.Row.RowType == DataControlRowType.DataRow)
          {
             string productgroup = ((GridView)sender).DataKeys[e.Row.RowIndex]["productGroup"].ToString();
             ObjectDataSource objDS = (ObjectDataSource)e.Row.FindControl("ODS2");
             objDS.SelectParameters["productGroup"].DefaultValue = productgroup;
          }
    
    }
