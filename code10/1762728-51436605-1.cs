    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
    	if (env.IsDevelopment())
    	{
    		app.UseDeveloperExceptionPage();
    		app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
    		{
    			HotModuleReplacement = true
    		});
    	}
    	else
    	{
    		app.UseExceptionHandler("/Home/Error");
    	}
    
    	app.UseStaticFiles();
    
    	app.UseCors("CorsPolicy");
    	app.UseSignalR(routes =>
    	{
    		routes.MapHub<ChatHub>("/chatHub");
    	});
    
    	app.UseMvc(routes =>
    	{
    		routes.MapRoute(
    			name: "default",
    			template: "{controller=Home}/{action=Index}/{id?}");
    	});
    }
    }
    }
