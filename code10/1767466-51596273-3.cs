    set 
    {
        // remove subscriptions
        if(_myClassCollection != null) 
        {
           foreach(var element in _myClassCollection)
           {
              element.PropertyChanged -= ElementChanged;
           } 
        }
         // set to new collection
        _myClassCollection = value;
        
        // subscribe to new elements.
        if(_myClassCollection != null) 
        {
           foreach(var element in _myClassCollection)
           {
              element.PropertyChanged += ElementChanged;
           } 
        }
        OnPropertyChanged("MyClassCollection");
        OnPropertyChanged("SelectedCount");  // Make the change Here.
    }
    private void ElementChanged(object sender, PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(MyClass.IsSelected))
        {
             OnPropertyChanged("SelectedCount");
        }
    }
