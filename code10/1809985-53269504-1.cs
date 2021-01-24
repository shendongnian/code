    var container = new WindsorContainer();
    container.AddFacility<TypedFactoryFacility>();
    container.Register(Component.For<Foo>());
    container.Register(
        Component.For<IFooFactory>()
            .AsFactory()
    );
