    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
    {
    	app.UseDeveloperExceptionPage();
    	app.UseStatusCodePages();
    	app.UseStaticFiles();
    	app.UseMvcWithDefaultRoute();
    
    	DbInitializer.Seed(serviceProvider.GetService<AppDbContext>());
    }
