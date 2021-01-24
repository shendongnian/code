    public void ConfigureServices(IServiceCollection services)
    {
                ...
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "app title", Version = "v1"});
                });
                services.AddSwaggerDocumentation();
                ...
    }
    public void Configure(IApplicationBuilder app)
    {
            ...
            app.UseSwagger((c) =>
            {
                c.RouteTemplate = "docs/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/swagger.json", "My API V1");
            });
            ...
    }
