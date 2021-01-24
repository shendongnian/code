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
