    container.RegisterType<IDevice, ActualDevice>("actual");
    container.RegisterType<IDevice, OtherActualDevice>("otherActual");
    container.RegisterType<IListener, Listener1>("listener1",
        new InjectionConstructor(
            new ResolvedParameter<IDevice>("actual")));
    container.RegisterType<IListener, Listener2>("listener2",
        new InjectionConstructor(
            new ResolvedParameter<IDevice>("otherActual")));
