    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    	app.UseCors(builder => builder
            .AllowAnyOrigin()
    		.AllowAnyMethod()
    		.WithHeaders("Accept", "Content-Type", "Origin", "X-My-Header"));
        //code omitted
    }
