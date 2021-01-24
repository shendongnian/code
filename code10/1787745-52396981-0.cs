    public void ConfigureServices(IServiceCollection services)
    {
         services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddApiExplorer()
                .AddAuthorization()
                .AddJsonFormatters()
                .AddCors();
    }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
    }
