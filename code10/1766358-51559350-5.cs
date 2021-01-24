    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContext dbContext)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }
        // app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseMvc();
        // ensure tables are created
        dbContext.Database.EnsureCreated();
    }
