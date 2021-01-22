    // get type information
    var type = typeof(MyClass);
    // get public constructors
    var ctors = type.GetConstructors(BindingFlags.Public);
    // invoke the first public constructor with no parameters.
    var obj = ctors[0].Invoke(new object[] { });
