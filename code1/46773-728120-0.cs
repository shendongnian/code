    protected override void InsertItem (int index, T item)
    {
        CheckReentrancy ();
        
        base.InsertItem (index, item);
        
        OnCollectionChanged (new NotifyCollectionChangedEventArgs (
            NotifyCollectionChangedAction.Add, item, index));
        OnPropertyChanged (new PropertyChangedEventArgs ("Count"));
        OnPropertyChanged (new PropertyChangedEventArgs ("Item[]"));
    }
