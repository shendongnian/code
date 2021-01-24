    UnityContainer container = new UnityContainer();
    
    container.RegisterType<IFoo, Foo>();
    container.RegisterType<IBar, Bar>();
    
    var bar = container.Resolve<IBar>(); // Foo will be automatically injected
    bar.Bar();
    // Bar Foo
