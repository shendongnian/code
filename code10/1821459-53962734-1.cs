      public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
   
            services.AddDataProtection()
                .SetApplicationName("vextus")
                .PersistKeysToRedis(ConnectionMultiplexer.Connect(Configuration.GetConnectionString("RedisConnection")),
                                    "DataProtection-Keys");
            services.AddDistributedRedisCache(o =>
            {
                o.Configuration = Configuration.GetConnectionString("RedisConnection");
            });
            services.AddSession(o =>
            {
                o.Cookie.Name = "vextus";
                o.Cookie.SameSite = SameSiteMode.None;
                o.Cookie.HttpOnly = true;
                o.IdleTimeout = TimeSpan.FromMinutes(10);
            });
        }
