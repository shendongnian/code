    public void ConfigureServices(IServiceCollection services) 
    {
        services.AddDistributedMemoryCache();
        services.AddSession();
        services.AddSession(options => {
    		options.IdleTimeout = TimeSpan.FromMinutes(60);
    	});
    	
    	services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    		.AddCookie();
    
        services.AddMvc();           
    
        services.AddDbContext<ModelContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }
    
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
    {
        if (env.IsDevelopment())
        {
            app.UseBrowserLink();
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }
    
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
    
        app.UseAuthentication();
    
        app.UseMvc(routes =>
    	{
    		routes.MapRoute(
    		   name: "admin",
    		   template: "{area}/{controller=Home}/{action=Index}/{id?}");
    		routes.MapRoute(
    			name: "default",
    			template: "{controller=Home}/{action=Index}/{id?}");               
    	});
    }   
