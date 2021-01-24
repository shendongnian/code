    //this is the constructor
    public EfGiacenzeRepo(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    //this is the method
    using (_aspContext = _serviceProvider.GetService<aspContext>())
    {
        listaGiacenze = _aspContext.TabGiacenza.ToList();
    }
