    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
	    app.UseMvc();
	    app.UseCookieAuthentication();
    }
