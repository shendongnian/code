    var builder = new ContainerBuilder();
    builder.RegisterCollection<ILogger>()
      .As<IEnumerable<ILogger>>();
    
    builder.Register<ConsoleLogger>()
      .As<ILogger>()
      .MemberOf<IEnumerable<ILogger>>();
    
    builder.Register<EmailLogger>()
      .As<ILogger>()
      .MemberOf<IEnumerable<ILogger>>();
