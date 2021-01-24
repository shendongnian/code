    private void Bars_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        NotifyPropertyChanged("Bars");
        NotifyPropertyChanged("This");
    }
