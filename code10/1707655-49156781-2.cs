    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        // Register the Swagger generator, defining one or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
        });
        services.AddMiniProfiler(options => 
            options.RouteBasePath = "/profiler"
        );
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMiniProfiler();
        app.UseSwagger();
        app.UseSwaggerUI(c => {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            c.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("SOMpSwaggerNetCore.SwaggerIndex.html");
        });
        app.UseMvc();
    }
