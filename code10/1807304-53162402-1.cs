    public static ISomeContainer Container { get; } = container = new SomeContainer();
    ...
    container.Register<IA, A>();
    container.Register<IB, B>();
    container.Register<IC, C>();
