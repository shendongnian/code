        if (e.Action == NotifyCollectionChangedAction.Remove)
        {
            foreach(T item in e.OldItems)
            {
                //Removed items
                item.PropertyChanged -= EntityViewModelPropertyChanged;
            }
        }
