    public ObservableCollection<double[]> Collection
    {
        set
        {
            collection= value;
            OnPropertyChanged("Collection");
        }
        get { return collection; }
    }
