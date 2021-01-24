        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //... some code
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
        }
