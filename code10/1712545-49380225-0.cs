    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<YourEFDbContext>();
        services.AddOData();
        services.AddMvc(config => {
             config.Filters.Add(new EnableQueryAttribute() {
                  PageSize = 100, //Default PageSize change to suit your needs
                  //This is used to speficy how many levels of related classes you can expand in your queries
                  MaxExpansionDepth = 3
                });
            });
     }
