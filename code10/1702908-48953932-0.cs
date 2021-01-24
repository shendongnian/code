    items.CollectionChanged += (s, e) =>
    {
        foreach (var o in e.OldItems.OfType<INotifyPropertyChanged>())
        {
            o.PropertyChanged -= Item_PropertyChanged;
        }
        foreach (var o in e.NewItems.OfType<INotifyPropertyChanged>())
        {
            o.PropertyChanged += Item_PropertyChanged;
        }
    };
