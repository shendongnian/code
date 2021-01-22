    protected override void InsertItem(int index, T item)
    {
        this.CheckReentrancy();
        base.InsertItem(index, item);
        this.OnPropertyChanged("Count");
        this.OnPropertyChanged("Item[]");
        this.OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
    }
 
