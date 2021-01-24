    public void ConfigureServices(IServiceCollection services)
    {
    	services.AddSignalR();
    	services.AddSingleton<IUserIdProvider, MyCustomProvider>();
    }
