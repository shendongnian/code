    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
    	app.Use(async (context, next) =>
    	{
    		await next.Invoke();
    		var statusCode = context.Response.StatusCode;
    		// ...
    	});
    
    	app.UseMvc();
    }
