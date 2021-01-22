    private Dictionary<string, string> Errors = new Dictionary<string, string>();
    private object _MyProperty;
    public object MyProperty
    {
       get { return _MyProperty; }
       set
       {
          Errors["MyProperty"] = null;
          if (value == _MyProperty)
          {
             return;
          }
          ValidateMyProperty(value);  // may set Errors["MyProperty"]
          if (Errors["MyProperty"] == null)
          {
             _MyProperty = value;
             OnPropertyChanged("MyProperty");
          }
       }
    }
    public string this[string propertyName]
    {
       return Errors[propertyName];
    }
