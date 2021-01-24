      Type type = typeof(Test1);
      //Get public fields
      List<FieldInfo> fieldInfo = type.GetFields().ToList();
      //Get private fields.  Ensure they are not a backing field.
      IEnumerable<FieldInfo> privateFieldInfo = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where(f => !f.Name.Contains("k__BackingField"));
      //Get public properties 
      List<PropertyInfo> properties = type.GetProperties().ToList();
      //Get private properties 
      properties.AddRange(type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance));
