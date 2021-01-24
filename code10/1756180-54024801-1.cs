    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        ...
        if (env.IsDevelopment())
        {
           //spa.UseAngularCliServer(npmScript: "start");
        }
    }
