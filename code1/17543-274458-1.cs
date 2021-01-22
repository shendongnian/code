    private void NeededCollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
    	e.Accepted = ((ShoppingListItem) e.Item).Needed;
    }
    
    private void BoughtCollectionViewSource_Filter(object sender, FilterEventArgs e)
    {
    	e.Accepted = !((ShoppingListItem) e.Item).Needed;
    }
