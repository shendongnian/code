    container.Register(Component
        .For<IService>()
        .ImplementedBy<FooService>()
        .Named("Foo"));
    container.Register(Component
        .For<IService>()
        .ImplementedBy<BarService>()
        .Named("Bar"));
    container.Register(Component
        .For<IService>()
        .ImplementedBy<BuzzService>()
        .Named("Buzz"));
    container.Register(Component
        .For<IService>()
        .ImplementedBy<AwesomeService>()
        .Named("Awesome"));
    container.Register(Component
        .For<Consumer>()
        .ServiceOverrides(new
            {
                services = new[] { "Foo", "Bar" }
            }));
    container.Register(Component.For<AnotherConsumer>());
    var consumer = container.Resolve<Consumer>();
