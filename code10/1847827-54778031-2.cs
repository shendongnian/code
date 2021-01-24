    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.Use(async (HttpContext context, Func<Task> next) =>
            {
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers.Add("X-Added-Key", "X-Added-Value");
                    return Task.CompletedTask;
                });
                await next();
            }).UseMvc();            
    }
