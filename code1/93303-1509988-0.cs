     public void yourListView_ItemEditing(Object sender, ListViewEditEventArgs e)
      {
        ListViewItem item = yourListView.Items[e.NewEditIndex];
        
        if((TextBox)item.FindControl("txtColor")) != null)
        {
           this.Color =    
              ((TextBox)item.FindControl("txtColor")).Text.Trim();
        }
 
      }
