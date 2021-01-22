    public void ConfigureServices(IServiceCollection services)
    {
    ...
        services.AddMvc()
 
             .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
    
        ...
    }
       
