    var asm = typeof(IServiceWrapper).Assembly;
    //note the name Namespace.ServiceWrapper`1
    //this is for calling Namespace.ServiceWrapper<>
    var type = asm.GetType("Namespace.ServiceWrapper`1");
    var genType = type.MakeGenericType(new Type[1] { typeof(T) });
    return (IServiceWrapper<T>)Activator
         .CreateInstance(genType, new object[1] { /*constructor parameter*/});
