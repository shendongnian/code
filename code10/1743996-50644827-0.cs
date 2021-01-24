    // example 1
    autofacBuilder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope();
    var container = autofacBuilder.Build();
    void _test1(IComponentContext scope){
        var myService = scope.Resolve<IMyService>();
    }
    void _test2(IComponentContext scope){
        // the same scope is used here and in _test1()
        // this means that the service instance will be the same here and there
        _test1(scope);
        var myService = scope.Resolve<IMyService>();
    }
    
    // it's only here that DI lifetime scope starts
    using (var scope = container.BeginLifetimeScope()) {
        _test2(scope);
    }
    
    
    
    // example 2
    autofacBuilder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope();
    var container = autofacBuilder.Build();
    void _test1(IComponentContext scope){
        var myService = scope.Resolve<IMyService>();
    }
    void _test2(IComponentContext scope){
        // now new scope is used in _test1() call
        // this means that instances will be different here and there since they are resolved from different scopes
        _test1(scope.BeginLifetimeScope());
        var myService = scope.Resolve<IMyService>();
    }
    
    var scope = container.BeginLifetimeScope();
    _test2(scope);
    
        
    
    // example 3
    // NOTE THIS!
    autofacBuilder.RegisterType<MyService>().As<IMyService>().InstancePerDependency();
    var container = autofacBuilder.Build();
    void _test1(IComponentContext scope){
        var myService = scope.Resolve<IMyService>();
    }
    void _test2(IComponentContext scope){
        // the same scope is used here and in _test1()
        // but now service instances will be different even though they are resolved from the same scope
        // since registration directs to create new instance each time the service is requested.
        _test1(scope);
        var myService = scope.Resolve<IMyService>();
    }
    
    var scope = container.BeginLifetimeScope();
    _test2(scope);
    
    
    
    // example 4
    autofacBuilder.RegisterType<MyService>().As<IMyService>().SingleInstance();
    var container = autofacBuilder.Build();
    void _test0(IComponentContext scope){
        var myService = scope.Resolve<IMyService>();
    }
    void _test1(IComponentContext scope){
        _test0(scope.BeginLifetimeScope());
        var myService = scope.Resolve<IMyService>();
    }
    void _test2(IComponentContext scope){
        // all the scopes used here and in other calls are different now
        // but the service instance will be the same in all of them even though it is requested from different scopes
        // since registration directs to get the same instance each time the service is requested regardless of the lifetime scope.
        _test1(scope.BeginLifetimeScope());
        var myService = scope.Resolve<IMyService>();
    }
    
    var scope = container.BeginLifetimeScope();
    _test2(scope);
    
