    static Type CreateNestedType()
    {
        var nestedType = Builders.CustomTypeBuilder.New(@namespace: "TestNameSpace")
                                 .AddProperty<string>("NestedProp")
                                 .Compile();
        var x = Activator.CreateInstance(nestedType);
        Console.WriteLine(x.GetType());
        // Toggling this line changes the behaviour of the debugger at the *next* breakpoint.
        //Debugger.Break();
        return nestedType;
    }
    static void Main(string[] args)
    {
        var nestedType = CreateNestedType();
        var propertyName = "NewProperty";
        
        var obj = Builders.CustomTypeBuilder.NewExtend<DummyClass>(@namespace: "TestNameSpace")
            .AddProperty(propertyName, nestedType)
            .Instantiate<DummyClass>();
        var nestedValue = Activator.CreateInstance(nestedType);
        
        nestedType.GetProperty("NestedProp").SetValue(nestedValue, "NestedValue");
        obj.GetType().GetProperty(propertyName).SetValue(obj, nestedValue);
        Debugger.Break();
    }
