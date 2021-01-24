    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
    {
        var kernel = app.ApplicationServices.GetService<IKernel>();
        
        // kernel registrations
        var applicationPartManager = app.ApplicationServices.GetRequiredService<ApplicationPartManager>();
        var controllerFeature = new ControllerFeature();
        applicationPartManager.PopulateFeature(controllerFeature);
        foreach (var type in controllerFeature.Controllers.Select(t => t.AsType()))
        {
            kernel.Bind(type).ToSelf().InTransientScope();
        }
        applicationLifetime.ApplicationStopping.Register(OnShutdown);
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseCors(
            options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
        );
        app.UseMvc();
    }
    
