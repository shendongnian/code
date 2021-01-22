    public void ConfigureServices(IServiceCollection services)
    {
 
        services
            .AddControllers()
            .AddJsonOptions(options => 
               options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
            );
        //...
     }
