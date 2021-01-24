    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(Startup.SetMvcOptions)
                .AddJsonOptions(Startup.SetJsonOptions);
    }
    
    private static void SetJsonOptions(MvcJsonOptions options)
    {
        options.SerializerSettings.Converters.Add(new CustomConverter());
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }
