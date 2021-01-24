       // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Need to add following linse
            services.Configure<KindSetting>(Configuration.GetSection("Kind1"));
         }
