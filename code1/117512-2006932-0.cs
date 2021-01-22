     protected void repValidationResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
     {
         RepeaterItem item = e.Item;
          if (item.ItemType == ListItemType.AlternatingItem || item.ItemType == ListItemType.Item)
            {
             
               HyperLink link = (HyperLink)    item.FindControl("link");    
               //Do all your logic here :)      
            }
     }
