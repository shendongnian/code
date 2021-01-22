     string _Value;
     public string Value
     {
        get
        {
           if (_Value == null)
           {
             _Value = CoalesceNullOrEmpty(Request.Form["valueA"],
               Request.Form["valueB"],
               "Default Value");
             }
           }
           return _Value;
        }
     }
    //Can place this in the page but is more useful in a utility dll
    public string CoalesceNullOrEmpty(params string[] values)
    {
      foreach(string value in values)
        if (!String.IsNullOrEmpty(value))
          return value;
      return null;
    }
