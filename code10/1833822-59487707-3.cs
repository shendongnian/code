         public void ConfigureServices(IServiceCollection services)
        {
         services.AddSession(options =>
                    {
                        options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time   
                    });
        			
        		services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        	app.UseSession();
          
        	UserSession.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
        }
        
