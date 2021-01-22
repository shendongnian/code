    protected void ItemDataBound(Object sender, DataListItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item || 
           e.Item.ItemType == ListItemType.AlternatingItem)
       {
           //process item data
       }
    }
