    public void ConfigureServices(IServiceCollection services)
            {
               
                services.AddOptions();
                services.Configure<AppConfiguration>(Configuration.GetSection("RestCalls"));
                services.AddMvc();
                
            }
