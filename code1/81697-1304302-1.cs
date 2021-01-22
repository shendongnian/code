      var types = new List<Type>
        {
          typeof (string),
          typeof (DateTime)
        };
      foreach (Type t in types)
      {
        // creates an object of the type represented by t
        object instance = Activator.CreateInstance(t);
        
        // this would cause an InvalidCastException, since instance is not of type 
        // System.Type, but instead either of type System.String or System.DateTime
        // Type t2 = (Type) instance;
        // to cast back to the actual type, additional runtime checks are needed here:
        if (instance is System.String)
        {
          string s = (string) instance;
        }
        
        else if (instance is DateTime)
        {
          DateTime d = (DateTime) instance;
        }
      }
