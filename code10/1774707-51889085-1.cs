            services.AddMvc(options => {
                var serviceProvider = services.BuildServiceProvider();
                var customJsonInputFormatter = new CustomJsonInputFormatter(
                         serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<CustomJsonInputFormatter>(),
                         serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value.SerializerSettings,
                         serviceProvider.GetRequiredService<ArrayPool<char>>(),
                         serviceProvider.GetRequiredService<ObjectPoolProvider>(),
                         options,
                         serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value
                    );
                options.InputFormatters.Insert(0, customJsonInputFormatter);
                
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
