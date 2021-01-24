    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        // other code here
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("AdditionalInfo", Environment.MachineName);
            await next.Invoke();
        });
        // additional code here
        app.UseMvc();
    }
