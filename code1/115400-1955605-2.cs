    private bool IsDiscontinuedItem(Item item)
    {
        return !item.ItemIsOnSite;
    }
 
    private bool IsPriceChangedItem(Item item)
    {
        return !PricingOptionIsValid(item);
    }
 
    private bool IsInvalidItem(Item item)
    {
        return IsDiscontinuedItem(item) ||
               IsPriceChangedItem(item);
    }
 
    private void RemoveInvalidItems()
    {
        itemList.RemoveAll(IsInvalidItem)
    }
