    MutableDocument CreateDocument(object data)
    {
       if (data == null) return null;
       var propertyValues = new Dictionary<string, object>();
       foreach (var property in data.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
       {
           propertyValues[property.Name] = property.GetValue(data);
       }
       return new MutableDocument(propertyValues);
     }
