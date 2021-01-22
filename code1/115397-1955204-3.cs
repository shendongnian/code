    var toRemove = lst.FindAll( 
            item => !PricingOptionIsValid(item) || !item.ItemIsOnSite() 
           );
    toRemove.ForEach( item => 
            {
                RemoveFromDB(item.ID);
                lst.Remove(item);
            });
   
