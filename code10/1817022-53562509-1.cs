            if(!IsPostBack)
               {
                  
                  LoadDropDownBox();  
        
        foreach (var item in aDbOperations.GetUserWithId(id)) //Passing query string here to match the id of the editing details
                  { 
                    ListItem selectedListItem = ddlUserRole.Items.FindByValue(item.roleId.ToString());
    
    if (selectedListItem != null)
    {
        selectedListItem.Selected = true;
    }
                  }
               }
