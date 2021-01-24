    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
    	app.UseMvc(routes =>
    	{
    		routes.Routes.Add(new SubdomainRouter(routes.DefaultHandler, "myexample.com", "User", "Profile"));
    
    		routes.MapRoute(
    			name: "default",
    			template: "{controller=Home}/{action=Index}/{id?}");
    	});
    }
