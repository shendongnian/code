    ItemsList.CollectionChanged += ItemsList_CollectionChanged;
    
    private void ItemsList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        GetFiles();
    }
