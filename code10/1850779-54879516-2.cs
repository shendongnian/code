      public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        loggerFactory.AddConsole(Configuration.GetSection("Logging"));
        loggerFactory.AddDebug();
    
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpStatusCodeExceptionMiddleware();
        }
        else
        {
            app.UseHttpStatusCodeExceptionMiddleware();
            app.UseExceptionHandler();
        }
    
        app.UseStaticFiles();
        app.UseMvc();
    }
