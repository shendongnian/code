    public void ConfigureDevelopmentServices(IServiceCollection services) 
            {
                services.AddMvc();
    
                services.AddDbContext<TriviaDbContext>(options =>
                                                       options.UseSqlite(Configuration.GetConnectionString("TriviaDb")));
            }
