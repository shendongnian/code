    public void Configure(IApplicationBuilder app)
    {
    	app.Use(next => context =>
    	{
    		context.Response.OnStarting(() =>
    		{
    			if (context.Response.StatusCode == 405)
    			{
    				context.Response.StatusCode = 404;
    			}
    
    			return Task.CompletedTask;
    		});
    
    		return next(context);
    	});
    }
