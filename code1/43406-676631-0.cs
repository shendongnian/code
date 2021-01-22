    public string GetValue(string propertyName, object MyInstance)
    {
      Type instanceType = typeof(MyInstance);
      // Set the BindingFlags depending on your property type or simply skip them.
      PropertyInfo pi = instanceType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
      
      // If this is an indexer property, provide the index as the second parameter,
      // else just supply null.
      return (pi.GetValue(MyInstance, null).ToString());
    }
