    public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
         NotifyCollectionChangedEventArgs args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
        OnCollectionChanged(args);
    }
