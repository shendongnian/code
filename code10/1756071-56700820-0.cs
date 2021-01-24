    public void ConfigureServices(IServiceCollection services)
    {
         //DataLayer namespace is in class library project
         services.AddDbContext<DataLayer.EFCoreContext>();
    }
