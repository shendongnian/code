    var kernel = new StandardKernel();
    kernel.Bind(scanner => scanner.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                                       .SelectAllClasses()
                                       .InheritedFrom<IPlugin>()
                                       .BindToAllInterfaces());
