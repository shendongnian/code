    protected override void InsertItem(int index, T item)
    {
      base.CheckReentrancy();
      base.InsertItem(index, item);
      base.OnPropertyChanged("Count");
      base.OnPropertyChanged("Item[]");
      base.OnCollectionChanged(NotifyCollectionChangedAction.Add, item, index);
    }
