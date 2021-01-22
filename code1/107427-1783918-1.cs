    // The assembly name/location could be configurable
    Assembly      assembly = Assembly.Load("MyAssembly.dll");
    // The type name could be configurable
    Type          type     = assembly.GetType("ConcreteEventHandler");
    IEventHandler handler  = Activator.CreateInstance(type) as IEventHandler;
    
