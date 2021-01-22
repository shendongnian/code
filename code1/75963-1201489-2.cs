    void lists_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
 
        if ( e.Item.ItemType == ListItemType.AlternatingItem 
            || e.Item.ItemType == ListItemType.Item )
        {
           Repeater oRepeater = (Repeater)e.Item.FindControl("listItems");
           // And to get the stuff inside.
           foreach ( RepeaterItem myItem in oRepeater.Items )
           {
              if ( myItem.Item.ItemType == ListItemType.AlternatingItem 
                  || myItem.Item.ItemType == ListItemType.Item )  
              {
                 Literal myContent = (Literal)myItem.FindControl("content");
                 // Do Something Good!
                 myContent.Text = "Huzzah!";
              }
           }
        }
    }
