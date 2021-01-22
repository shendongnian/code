    ObservableCollection<INotifyPropertyChanged> items = new ObservableCollection<INotifyPropertyChanged>();
    items.CollectionChanged += items_CollectionChanged;
    
    static void items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.OldItems != null)
        {
            foreach (INotifyPropertyChanged item in e.OldItems)
                item.PropertyChanged -= item_PropertyChanged;
        }
        if (e.NewItems != null)
        {
            foreach (INotifyPropertyChanged item in e.NewItems)
                item.PropertyChanged += item_PropertyChanged;
        }
    }
    
    static void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
