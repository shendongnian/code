        if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach(T item in e.NewItems)
            {
                //Removed items
                item.PropertyChanged -= EntityViewModelPropertyChanged;
            }
        }
