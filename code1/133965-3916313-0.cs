    public static CustomAttributeBuilder ToAttributeBuilder(this CustomAttributeData data)
    {
      if (data == null)
      {
        throw new ArgumentNullException("data");
      }
    
      var constructorArguments = new List<object>();
      foreach (var ctorArg in data.ConstructorArguments)
      {
        constructorArguments.Add(ctorArg.Value);
      }
    
      var propertyArguments = new List<PropertyInfo>();
      var propertyArgumentValues = new List<object>();
      var fieldArguments = new List<FieldInfo>();
      var fieldArgumentValues = new List<object>();
      foreach (var namedArg in data.NamedArguments)
      {
        var fi = namedArg.MemberInfo as FieldInfo;
        var pi = namedArg.MemberInfo as PropertyInfo;
    
        if (fi != null)
        {
          fieldArguments.Add(fi);
          fieldArgumentValues.Add(namedArg.TypedValue.Value);
        }
        else if (pi != null)
        {
          propertyArguments.Add(pi);
          propertyArgumentValues.Add(namedArg.TypedValue.Value);
        }
      }
      return new CustomAttributeBuilder(
        data.Constructor,
        constructorArguments.ToArray(),
        propertyArguments.ToArray(),
        propertyArgumentValues.ToArray(),
        fieldArguments.ToArray(),
        fieldArgumentValues.ToArray());
    }
