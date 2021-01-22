    public void SetProperty<T>(string propertyName, ref T field, T value)
     { field = value;
       NotifyPropertyChanged(propertyName);
     }
    public Foo MyProperty 
     { get { return _myProperty}
       set { SetProperty("MyProperty",ref _myProperty, value);}
     } Foo _myProperty;
