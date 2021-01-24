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
        app.UseWhen(
            context => !context.Request.Path.StartsWithSegments("/api"),
            appBuilder =>
            {
                appBuilder.ApplyKeyValidation();
                appBuilder.ApplyPolicyValidation();
            }
        );
        app.UseHttpsRedirection();
        app.UseMvc();       
    }
