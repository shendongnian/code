    public void ConfigureServices(IServiceCollection services)
    {
        // ...
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(o =>{
               o.SerializerSettings.ContractResolver =new IgnoreZeroContractResolver();
            });
        
        // ...
    }
