        private IServiceCollection BuildCommonServices(out AggregateException hostingStartupErrors)
        {
            //... code removed for brevity
            var services = new ServiceCollection();
            services.AddSingleton(_options);
            services.AddSingleton<IHostingEnvironment>(_hostingEnvironment);
            services.AddSingleton<Extensions.Hosting.IHostingEnvironment>(_hostingEnvironment);
            services.AddSingleton(_context);
            var builder = new ConfigurationBuilder()
                .SetBasePath(_hostingEnvironment.ContentRootPath)
                .AddConfiguration(_config);
            _configureAppConfigurationBuilder?.Invoke(_context, builder);
            var configuration = builder.Build();
            services.AddSingleton<IConfiguration>(configuration);
            _context.Configuration = configuration;
            var listener = new DiagnosticListener("Microsoft.AspNetCore");
            services.AddSingleton<DiagnosticListener>(listener);
            services.AddSingleton<DiagnosticSource>(listener);
            services.AddTransient<IApplicationBuilderFactory, ApplicationBuilderFactory>();
            services.AddTransient<IHttpContextFactory, HttpContextFactory>();
            services.AddScoped<IMiddlewareFactory, MiddlewareFactory>();
            services.AddOptions();
            services.AddLogging();
