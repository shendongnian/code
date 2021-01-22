    bool ShouldBeRemoved(MyItemType item)
    {
        return !PricingOptionIsValid(item) || !item.ItemIsOnSite();
    }
    
    lst.RemoveAll(ShouldBeRemoved); //this does the same thing as what the lambda does
