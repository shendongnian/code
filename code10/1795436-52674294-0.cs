    public void ConfigureServices(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
                cfg.AddProfile(new SqlAutoMapperConfig());
            });
    
            services.AddSingleton(config.CreateMapper());
    
            services.AddMvc();
    
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            _container.Register<IMapper>(() => mapperConfig.CreateMapper(_container.GetInstance));
        }
