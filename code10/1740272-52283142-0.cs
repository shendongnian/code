    public void ConfigureServices(IServiceCollection services)
    {
      ...
      services.AddCors(options =>{
         options.AddPolicy("MyAppCorsPolicy", x => {
            x.WithOrigin("*.contoso.com", "*.example.com", ...);
            x.AllowAnyHeader();
            x.WithMethods("GET", "POST", "PUT", "PATCH", ...);
         });
      });
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      ...
      app.UseCors("MyAppCors");
      app.UseMvc();
    }
