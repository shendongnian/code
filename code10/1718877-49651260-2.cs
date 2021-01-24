csharp
public static class ServiceCollectionExtensions {
    public static void AddServices(
        this IServiceCollection services,
        Action<ServiceOptions> configureOptions)
    {
        // Configure service
        services.AddSingleton<IAbstraction, Implementation>();
        // Configure and validate options
        services.AddOptions<ServiceOptions>()
            .Configure(configureOptions)
            .Validate(options => {
                // Take the fully configured options and return validity...
                return options.Option1 != null;
            });
    }
}
# ASP.NET Core 2.0+
From ASP.NET Core 2.0 onwards, `PostConfigure` is a good fit. This function takes a configuration delegate too but is executed last, so everything is already configured.
    public static class ServiceCollectionExtensions {
        public static void AddServices(
            this IServiceCollection services,
            Action<ServiceOptions> configureOptions)
        {
            // Configure service
            services.AddSingleton<IAbstraction, Implementation>();
            // Configure and validate options
            services.Configure(configureOptions);
            services.PostConfigure<ServiceOptions>(options => {
                // Take the fully configured options and run validation checks...
                if (options.Option1 == null) {
                    throw new Exception("Option1 has to be specified");
                }
            });
        }
    }
