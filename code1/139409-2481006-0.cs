    protected override void ClearItems()
    {
        this.CheckReentrancy();
        base.ClearItems();
        this.OnPropertyChanged("Count");
        this.OnPropertyChanged("Item[]");
        this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }
