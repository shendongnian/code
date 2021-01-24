    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
    	app.UseCors("MyCorsPolicy");
        //code omitted
    }
