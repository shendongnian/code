    public void Configure(IApplicationBuilder app, IApplicationLifetime appLifetime)
    {
    	app.UseMvc();           
    	appLifetime.ApplicationStopped.Register(() => ApplicationContainer.Dispose());
    }
