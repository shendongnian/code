    public void ConfigureServices(IServiceCollection services)
    {
        // needs a reference in your `csproj` file to `Microsoft.AspNetCore.Mvc.Formatters.Json`
        services.AddJsonOptions(Startup.SetJsonOptions);
    }
    
    private static void SetJsonOptions(MvcJsonOptions options)
    {
        options.SerializerSettings.Converters.Add(new CustomConverter());
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
    }
