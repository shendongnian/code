    items.CollectionChanged += (s, e) =>
    {
        foreach (var item in e.OldItems.OfType<INotifyPropertyChanged>())
        {
            item.PropertyChanged -= Item_PropertyChanged;
        }
        foreach (var item in e.NewItems.OfType<INotifyPropertyChanged>())
        {
            item.PropertyChanged += Item_PropertyChanged;
        }
    };
