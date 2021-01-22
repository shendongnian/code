    /// <summary>Set the value of this property, as an object.</summary>
    public static void SetPropertyValue(this object obj, 
                                        string propertyName, 
                                        object objValue)
    {
      const BindingFlags attr = BindingFlags.Public | BindingFlags.Instance;
      var type = obj.GetType();
      
      var property = type.GetProperty(propertyName, attr);
      if(property == null) return;
      var propertyType = property.PropertyType;
      if (propertyType.IsValueType && objValue == null)
      {
        // This works for most value types, but not custom ones
        objValue = 0;
      }
      // need to change some types... e.g. value may come in as a string...
      var realValue = Convert.ChangeType(objValue, propertyType);
      property.SetValue(obj, realValue, null);
    }
