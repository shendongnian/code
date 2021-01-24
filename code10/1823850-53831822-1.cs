    var props = TypeDescriptor.GetProperties(new TestClass3());
    foreach(PropertyDescriptor prop in props)
    {
        Console.WriteLine($"{prop.Category}: {prop.Name}");
    }
