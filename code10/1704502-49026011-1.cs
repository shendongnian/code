    public sealed class MainViewModel
    {
        private ObservableCollection<ItemViewModel> items;
        public ObservableCollection<ItemViewModel> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ObservableCollection<ItemViewModel>();
                    items.CollectionChanged += ItemsCollectionChanged;
                }
                return items;
            }
        }
        private void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    // we want to be notified, if IsChecked is changed;
                    // ObservableCollection<T> adds one item per time, so, we just using NewItems[0]
                    ((ItemViewModel)e.NewItems[0]).PropertyChanged += ItemPropertyChanged;
                    break;
                case NotifyCollectionChangedAction.Remove:
                    // we need to unsibscribe, when removing item from collection,
                    // to avoid memory leak
                    ((ItemViewModel)e.OldItems[0]).PropertyChanged -= ItemPropertyChanged;
                    break;
            }
        }
        private void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // we're interested only in IsCheckedProperty
            if (e.PropertyName == nameof(ItemViewModel.IsChecked))
            {
                // let's update our list
                UpdateItemTextValues();
            }
        }
        private void UpdateItemTextValues()
        {
            // retrieving NameN property values from checked items as a single list
            var itemTextValues = Items
                .Where(_ => _.IsChecked)
                .Select(_ => new[]
                {
                    _.Name1,
                    _.Name2
                })
                .SelectMany(_ => _)
                .ToList();
            // do somethig with the list
            Trace.WriteLine(null);
            foreach (var value in itemTextValues)
            {
                Trace.WriteLine(value);
            }
        }
    }
