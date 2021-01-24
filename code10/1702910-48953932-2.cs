    items.CollectionChanged += (s, e) =>
    {
        if (e.OldItems != null)
        {
            foreach (var item in e.OldItems.OfType<INotifyPropertyChanged>())
            {
                item.PropertyChanged -= Item_PropertyChanged;
            }
        }
        if (e.NewItems != null)
        {
            foreach (var item in e.NewItems.OfType<INotifyPropertyChanged>())
            {
                item.PropertyChanged += Item_PropertyChanged;
            }
        }
    };
