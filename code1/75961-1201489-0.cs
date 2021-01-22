    void lists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
 
        if ( e.Item.ItemType == ListItemType.AlternatingItem 
            || e.Item.ItemType == ListItemType.Item )
        {
           var oRepeater = (Repeater)e.Item.FindControl("listItems");
        }
    }
