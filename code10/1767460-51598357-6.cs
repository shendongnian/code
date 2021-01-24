    public void ConfigureServices(IServiceCollection services)  
    {  
        ...
        services.AddMvc(  
            config => config.ModelBinderProviders.Insert(0, new CustomModelBinderProvider())  
        ); 
        ... 
    } 
