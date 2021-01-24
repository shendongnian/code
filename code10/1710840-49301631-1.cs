    container.CrossWire<ILoggerFactory>(app);
    container.RegisterConditional(
        typeof(ILogger),
        c => typeof(Logger<>).MakeGenericType(c.Consumer.ImplementationType),
        Lifestyle.Singleton,
        c => true);
