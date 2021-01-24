     public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IMapperFactory, MapperFactory>();
            services.AddScoped<ITestService, testtService>();
            
                          
           // services.AddScoped<IMapperFactory, MapperFactory>();
        }
