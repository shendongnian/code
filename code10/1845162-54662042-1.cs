    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .AllowCredentials()
        );
    }
