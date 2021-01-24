    private void DisableCorrelationIds(IServiceCollection services)
    {
        var module = services.FirstOrDefault(t =>
            t.ImplementationFactory?.GetType() == typeof(Func<IServiceProvider, DependencyTrackingTelemetryModule>));
        if (module != null)
        {
            services.Remove(module);
            services.AddSingleton<ITelemetryModule>(provider => new DependencyTrackingTelemetryModule
            {
                SetComponentCorrelationHttpHeaders = false
            });
        }
    }
    public void ConfigureServices(IServiceCollection services)
    {
        // other stuff may come here
        DisableCorrelationIds(services);
    }
