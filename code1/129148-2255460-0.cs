    oCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(oCollection_CollectionChanged);
    
    private void oCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        CalculatedBalance();
    }
