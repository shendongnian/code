    items.CollectionChanged += (object sender, NotifyCollectionChangedEventArgs e) =>
    {
        foreach (var item in items.OfType<INotifyPropertyChanged>()) //filter the list
        {
            item.PropertyChanged += Item_PropertyChanged;
        }
    };
