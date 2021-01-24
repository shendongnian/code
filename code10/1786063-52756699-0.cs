        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            var builder = new ContainerBuilder();
            builder.RegisterType<CalculationService>().As<ICalculationService>();
            builder.RegisterType<Logger>().As<ILogger>();
            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider diService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseMvc();
            var injection = new Injector(diService);
            var result = injection.RunMethod(typeof(ICalculationService).FullName, "Sum", new int[] { 1, 2, 3 });
        }
