    private string _MyProperty;
    public string MyProperty
    {
       get { return _MyProperty; }
       set
       {
          // at this point, value contains what the user just typed, and 
          // _MyProperty contains the property's previous value.
          if (value != _MyProperty)
          {
             _MyProperty = value;
             // assuming you've implemented INotifyPropertyChanged in the usual way...
             OnPropertyChanged("MyProperty"); 
          }
       }
