      public string this[string index]  
      {
        if (propertyValues.ContainsKey(propertyName))
        {
          return propertyValues[propertyName];
        }
        else
        {
          return null;
        }
      }
