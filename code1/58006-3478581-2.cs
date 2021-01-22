    ObservableCollection<INotifyPropertyChanged> items = 
                                  new ObservableCollection<INotifyPropertyChanged>();
    items.CollectionChanged += 
        new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
                                                            items_CollectionChanged);
    
    static void items_CollectionChanged(object sender, 
                   System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        foreach (INotifyPropertyChanged item in e.OldItems)
            item.PropertyChanged -= new 
                                   PropertyChangedEventHandler(item_PropertyChanged);
        foreach (INotifyPropertyChanged item in e.NewItems)
            item.PropertyChanged += 
                               new PropertyChangedEventHandler(item_PropertyChanged);
    }
    static void item_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        throw new NotImplementedException();
    }
