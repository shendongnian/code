    private void Loop()
    { 
        foreach (Item i in itemList)
        {
        	 if(!item.ItemIsOnSite)
        	 {
        	 	RemoveDiscontinuedItems(i)
        	 }
        	 if(!item.PricingOptionIsValid)
             {
             	RemovePriceChangedItems(i)
             }
        
        }
    }
    
    private void RemoveDiscontinuedItems(itemType item)
    {
    
        RemoveItem(item.Id); // remove it from the DB
        item.Remove; // remove it from the collection              
    
    }
    
    private void RemovePriceChangedItems(itemType item)
    {
        RemoveItem(item.Id); // remove it from the DB
        item.Remove; // remove it from the collection
    
    }
