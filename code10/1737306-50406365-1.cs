    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
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
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseMvc();
    }
