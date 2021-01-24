    public MyViewModel()
    {
        // Setup Collection, with a CollectionChanged event
        Components = new ObservableCollection<Component>();
        Components.CollectionChanged += Components_CollectionChanged;
    
    }
    
    // In the CollectionChanged event (items getting added or removed from collection),
    // hook up the PropertyChanged event
    void Components_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems != null)
            foreach(MyType item in e.NewItems)
                item.PropertyChanged += Component_PropertyChanged;
    
        if (e.OldItems != null)
            foreach(MyType item in e.OldItems)
                item.PropertyChanged -= Component_PropertyChanged;
    }
    
    // In the PropertyChanged event, run some code if SelectedComponent property changed
    void Component_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "SelectedComponent")
            DoWork();
    } 
