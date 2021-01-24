        public void Configure(IServiceCollection services)
        {
            services.Inject();
            // and whatever else you need 
            services.AddMvc();
        }
