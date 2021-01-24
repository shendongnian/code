    pivate class TestCommand : BaseCommand
    {
        public TestCommand(Type realCommandType)
        {
        }
    }
    // ...
    // that's all the IServiceProvider mocking you need
    var serviceProvider = new Mock<IServiceProvider>();
    var activator = new Mock<IActivator>();
    activator.Setup(_ => _.CreateInstance(serviceProvider, It.IsAny<Type>())
        .Returns<IServiceProvider, Type>((sp, t) => new TestCommand(t));
    // ...
    foreach (var expectedType in typeof(CommandDispatcher).Assembly.GetTypes()
       .Where(t => t.IsSubclassOf(typeof(BaseCommand)) && !t.IsAbstract))
    {
        // check, whether whatever you do with commandsInAssembly 
        // contains a TestCommand with expectedType 
    }
