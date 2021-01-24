    var token = "TestNameSpace";
    var nestedType = Builders.CustomTypeBuilder.New(@namespace: token).AddProperty<string>("NestedProp").Compile();
    var propertyName = "NewProperty";
    // Instantiated, but not assigned to a local variable
    Console.WriteLine(Activator.CreateInstance(nestedType));
    
    var obj = Builders.CustomTypeBuilder.NewExtend<DummyClass>(@namespace: token)
        .AddProperty(propertyName, nestedType)
        .Instantiate<DummyClass>();
    var nestedValue = Activator.CreateInstance(nestedType);
    
    nestedType.GetProperty("NestedProp").SetValue(nestedValue, "NestedValue");
    obj.GetType().GetProperty(propertyName).SetValue(obj, nestedValue);
    Debugger.Break();
