    private void Documents_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        foreach(Document item in e.NewItems)
        {
            item.IsNew = true;
        }
    }
