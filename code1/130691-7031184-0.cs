    public string MyProperty
    {
       get { return _Model.MyProperty; } 
       set
       {
          _Model.MyProperty=value;
          OnPropertyChanged("MyProperty");
       }
    }
