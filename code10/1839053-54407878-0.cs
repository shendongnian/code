    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
     {
       app.UseSwaggerUI(c =>
         {
          c.SwaggerEndpoint("./swagger/v1/swagger.json", "Test.Web.Api");
          c.RoutePrefix = string.Empty;
        });
     }
