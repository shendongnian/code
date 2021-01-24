    container.RegisterConditional(
        typeof(ILogger),
        c => typeof(Logger<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Singleton,
        c => true);
    // This next call is not required if you are already calling AutoCrossWireAspNetComponents
    container.CrossWire<ILoggerFactory>(app);
