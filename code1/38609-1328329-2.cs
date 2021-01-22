    Protected Void YourList_ItemDataBound(Object sender, DataListItemEventArgs e)
    {
       if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem )
      {
        ((Label)e.Item.FindControl("LabelName")).Text = 
           DataBinder.Eval(((DataListItem)sender.Parent).DataItem, "FieldName");
        
      }
    }
