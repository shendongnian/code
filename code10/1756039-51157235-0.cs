    ...
    public void ConfigureServices(IServiceCollection services) {
      services.AddCors();       /* <----- Added this line before de MVC */
      services.AddMvc();
    }
    ...
    public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }
      app.UseCors(builder => builder.WithOrigins("http://localhost:4200")); /* <----- Added this line before de MVC */
      app.UseMvc();
    }
