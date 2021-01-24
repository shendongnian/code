                services.AddMvc(o =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var customJsonInputFormatter = new CustomFormatter(
                         serviceProvider.GetRequiredService<ILoggerFactory>().CreateLogger<CustomFormatter>(),
                         serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value.SerializerSettings,
                         serviceProvider.GetRequiredService<ArrayPool<char>>(),
                         serviceProvider.GetRequiredService<ObjectPoolProvider>(),
                         o,
                         serviceProvider.GetRequiredService<IOptions<MvcJsonOptions>>().Value
                    );
                o.InputFormatters.Insert(0, customJsonInputFormatter);
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
  
   
