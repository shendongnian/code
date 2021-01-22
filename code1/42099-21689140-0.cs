        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType ==                 ListItemType.AlternatingItem))
         {
           if (e.Item.DataItem is DataRowView)
           {
        	 DataRowView rowView = (DataRowView)e.Item.DataItem;
        	 String state = rowView[PutYourColumnHere].ToString();
        	 if (state.Equals("PutYourConditionHere"))
        	 {
        	   //your formating, in my case....
        	   e.Item.CssClass = "someClass";
        	 }
           }
         }
