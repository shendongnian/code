    container.AddFacility<FactorySupportFacility>();
    container.Register(Component.For<IRepositoryFactory>()
        .ImplementedBy<MyRepositoryFactory>()
        .LifeStyle.PerWebRequest);
    container.Register(Component.For<Repository>()
        .UsingFactory((IRepositoryFactory f) => f.Create())
        .LifeStyle.PerWebRequest);
