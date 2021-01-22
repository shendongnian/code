    void Connections_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        NotifyCollectionChangedEventArgs args = GetCollectionChangedArgs(e, this.nodes.Count);
        CollectionChanged(this, args);
    }
    
    public static NotifyCollectionChangedEventArgs GetCollectionChangedArgs(NotifyCollectionChangedEventArgs e, int offset)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                return new NotifyCollectionChangedEventArgs(e.Action, e.NewItems, e.NewStartingIndex + offset);
    	
            case NotifyCollectionChangedAction.Move:
                return new NotifyCollectionChangedEventArgs(e.Action, e.NewItems, e.NewStartingIndex + offset, e.OldStartingIndex + offset);
    
            case NotifyCollectionChangedAction.Remove:
                return new NotifyCollectionChangedEventArgs(e.Action, e.OldItems, e.OldStartingIndex + offset);
    				
            case NotifyCollectionChangedAction.Replace:
                return new NotifyCollectionChangedEventArgs(e.Action, e.NewItems, e.OldItems, e.OldStartingIndex + offset);
    				
            case NotifyCollectionChangedAction.Reset:
                return new NotifyCollectionChangedEventArgs(e.Action);
        }
    }
