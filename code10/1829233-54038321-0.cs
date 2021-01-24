        public static IWebHostBuilder UseCustomLogger(this IWebHostBuilder builder, CustomLogger logger = null, bool dispose = false)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            builder.ConfigureServices(collection =>
                collection.AddSingleton<ILoggerFactory>(services => new CustomLoggerFactory(logger, dispose)));
            return builder;
        }
