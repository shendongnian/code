         public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
         
            var conn = Configuration.GetValue<string>("RedisCache:Configuration");
            var redis = ConnectionMultiplexer.Connect(conn);
            services.AddDataProtection()
                .PersistKeysToRedis(redis, "DataProtection-Keys");
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
