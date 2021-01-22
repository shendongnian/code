    protected void criteriaScore_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
        // This event is raised for the header, the footer, separators, and items.
        
        // Execute the following logic for Items and Alternating Items.
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType ==   
            ListItemType.AlternatingItem) 
        {
             DropDownList ddl = (DropDownList)e.Item.FindControl("ddlRating");
        
             for(int i=0; i < 5; i++)
             {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
             }
        }
     }  
