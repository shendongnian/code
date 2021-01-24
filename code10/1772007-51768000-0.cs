    public void Configure(IApplicationBuilder app)
    {
        app.Map("/Api", BuildApiBranch);
     
        // middlewares for the mvc app, e.g.
        app.UseStaticFiles();
        // some other middlewares maybe...
        app.UseMvc(...);
    }
    private static void BuildApiBranch(IApplicationBuilder app)
    {        
        // middlewares for the web api...
        app.UseMvc(...);
    }
