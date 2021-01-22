    void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          if (!Roles.IsUserInRole("Admin"))
          {
            // Hide the edit controls.
            // This would be your "Edit" button or something.
            e.Row.Cells[1].Controls[0].Visible = false;  
          }
        }
      }
