    public object MyProperty
    {
       set { _MyProperty = Validate("MyProperty", value, _MyProperty); }
    }
    private Dictionary<string, Func<object, string>> ValidationFunctions;
    private object Validate(string propertyName, object value, object field)
    {
       Errors[propertyName] = null;
       if (value == field)
       {
          return;
       }
       if (!ValidationFunctions.ContainsKey(propertyName))
       {
          return value;
       }
       Errors[propertyName] = ValidationFunctions[propertyName](value);
       return (Errors[propertyName] == null) 
          ? value 
          : field;
       }
    }
