    public void ConfigureServices(IServiceCollection services)
    {
       services.AddMvc();
       services.AddSingleton<ITelemetryInitializer, CustomTelemetry>();
       services.AddApplicationInsightsTelemetry();
    }
