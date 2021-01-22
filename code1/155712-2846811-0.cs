    protected void rgPeople_ItemCreated(object sender, GridItemEventArgs e)
    {
       if(e.Item.ItemType = GridItemType.AlternatingItem Or e.Item.ItemType =                          GridItemType.Item)
        {    
            Telerik.WebControls.GridDataItem item = e.Item;
            Label lbl as Label;
            lbl= item("ColumnName").FindControl("lblName")
            
        }
    }
