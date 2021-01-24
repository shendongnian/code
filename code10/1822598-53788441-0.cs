    builder.RegisterType<Implementation>().AsSelf();
    builder.Register(c =>
    {
      ProxyGenerator proxyGen = new ProxyGenerator(true);
      return proxyGen.CreateInterfaceProxyWithTargetInterface<IInterfaceOfImplementation>(
        c.Resolve<Implementation>(),
        c.Resolve<ExceptionCatcherInterceptor>());
    }).As<IInterfaceOfImplementation>();
