    var builder = new ContainerBuilder();
    
    builder.RegisterGeneric(typeof(SomeInstance1<>))
      .As(typeof(IGenericInterface<>));              
    
    var container = builder.Build();
    
    var instance1 = container.Resolve<IGenericInterface<SubClass1>>();
    
    Assert.IsInstanceOfType(typeof(SomeInstance1<SubClass1>), instance1);
