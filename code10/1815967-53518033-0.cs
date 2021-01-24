        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("...")));
            var serviceProvider = services.BuildServiceProvider();
            var localMyDbContext = serviceProvider.GetRequiredService<MyDbContext>();
            Processor = new QueueProcessor(localDbContext, Configuration.GetConnectionString("Other"));
            Processor.RunAsync().GetAwaiter().GetResult();
            return serviceProvider;
        }
