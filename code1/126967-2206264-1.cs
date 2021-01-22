    Type classType = typeof(TestClass);
    object[] classAttributes = classType.GetCustomAttributes(false); 
    foreach(PropertyInfo property in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
      object[] propertyAttributes = property.GetCustomAttributes(false); 
      Console.WriteLine(property.Name);
    }
