    //if class is in same assembly
    var namespace = typeof(SomeKnownTypeInNamespace).Namespace;
    Type type = Type.GetType(namespace + "." + "MyClass");
    //or for cases of referenced classes
    var assembly = typeof(SomeKnownTypeInAssembly).Assembly;
    var namespace = typeof(SomeKnownTypeInNamespace).Namespace;
    Type type = assembly.GetType(namespace + "." + "MyClass");
    //or
    Type type = Type.GetType(namespace + "." + "MyClass" + ", " + assembly.GetName().Name);
