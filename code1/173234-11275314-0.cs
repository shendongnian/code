    #region Control Event Clean up
    private event NotifyCollectionChangedEventHandler CollectionChangedFiles
    {
        add { FC.CollectionChanged += value; }
        remove { FC.CollectionChanged -= value; }
    }
    #endregion Control Event Clean up
