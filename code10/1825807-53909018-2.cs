    var myClassType = typeof(MyClass);
    var myClass = new MyClass();
    var assemblyTypes = Assembly.GetExecutingAssembly().GetTypes();
    foreach (var type in assemblyTypes.Where(t => t.GetCustomAttribute<ExtensionAttribute>() != null)
    {
        var typeMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
        foreach (var method in typeMethods.Where(m => m.IsDefined(typeof(ExtensionAttribute), inherit: false))
        {
            if (method.GetParameters()[0].ParameterType == myClassType)
            {
                // here you go
                method.Invoke(null, new object[]{ myClass });
            }
        }
    }
