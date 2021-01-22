     void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          RadioButtonList list = (RadioButtonList)e.Row.FindControl("rbList");
          if(list != null)
          {
             list.DataSource = mysource;
             list.DataBind();
          }
        }
       }
