    Type type = typeof(Test321);
    object obj1 = Activator.CreateInstance(type);
    PropertyInfo prop1 = type.GetProperty("Test");
    object obj2 = Activator.CreateInstance(prop1.PropertyType);
    PropertyInfo prop2 = prop1.PropertyType.GetProperty("Test");
    prop2.SetValue(obj2, 123, null);
    prop1.SetValue(obj1, obj2, null);
