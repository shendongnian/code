    Type classType = typeof(TestClass);
    foreach(PropertyInfo property in classType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
    {
      Console.WriteLine(property.Name);
    }
