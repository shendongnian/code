      var types = new List<Type>
        {
          typeof (string),
          typeof (DateTime)
        };
      foreach (Type t in types)
      {
        object instance = Activator.CreateInstance(t);
        
        if (instance is System.String)
        {
          string s = (string) instance;
        }
        
        else if (instance is DateTime)
        {
          DateTime d = (DateTime) instance;
        }
      }
