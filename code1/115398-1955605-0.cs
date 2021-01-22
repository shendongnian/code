    private void RemoveDiscontinuedItems()
    {
        itemList.RemoveAll(x => !x.ItemIsOnSite);
    }
    private void RemovePriceChangedItems()
    {
        itemList.RemoveAll(x => !PricingOptionIsValid(x));
    }
	
