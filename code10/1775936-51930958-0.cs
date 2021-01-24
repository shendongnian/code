    public void Configure(IApplicationBuilder app)
    {
        app.Map("/webapi", ConfigureWebApiBranch);
        // configuration of your Razor Pages app pipeline...
        app.UseMvc(...);
    }
    public void ConfigureWebApiBranch(IApplicationBuilder app)
    {
        // configuration of your Web Api app pipeline...
        app.UseMvc(...);
    }
