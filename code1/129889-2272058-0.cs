      protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
        if(e.Row.RowType == DataControlRowType.DataRow)
        { 
          LinkButton _bt = e.Row.FindControl("ID") as LinkButton;
          if(_bt != null)
          {
            // have a look at the e.row.DataItem and try to get the value of your desired visibility property
            _bt.Visible = true;
          }
        }
      }
