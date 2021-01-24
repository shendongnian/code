    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        services.AddAuthentication("ApiKeyAuth")
                .AddScheme<ApiKeyAuthOpts,ApiKeyAuthHandler>("ApiKeyAuth","ApiKeyAuth",opts=>{ });
    }
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // ...
        app.UseAuthentication();
        app.UseHttpsRedirection();
        app.UseMvc();
    }
