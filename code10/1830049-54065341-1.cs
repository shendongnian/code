        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
    
                 int itemIndex =  e.Item.ItemIndex;
                 Label lblIdComponente = (Label)e.Item.FindControl("lblIdComponente");                  
                    lblIdComponente.ID = itemIndex.ToString();
    
                // Similar logic for other control IDs
            }
