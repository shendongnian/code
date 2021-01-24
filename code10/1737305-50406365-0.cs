    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.Use(async (context, next) =>
        {
            try
            {
                await next();
            }
            finally
            {
                var test = context.Response.StatusCode;
            }
        });
        app.UseMvc();
    }
