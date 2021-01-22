    T SomeProperty()
    {
        get
        {
           return _someProperty;
        }
        set
        {
           if (_someProperty <> value)
           {
              _someProperty = value;
              OnPropertyChanged("SomeProperty");
           }
        }
    }
