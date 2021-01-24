    public static void Main(string[] args)
    {
        var builder = new ContainerBuilder();
        builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
        builder.RegisterType<ServiceImpl>().As<Service>()
            .OnActivated(e => Service.UnitOfWork = e.Context.Resolve<IUnitOfWork>());
        var container = builder.Build();
        var service = container.Resolve<Service>();
        Console.WriteLine(Service.UnitOfWork);
        Console.ReadKey();
    } 
