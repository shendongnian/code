    public void Configure(IApplicationBuilder app)  
    {
        app.UseStatusCodePages(async context =>
        {
            context.HttpContext.Response.ContentType = "text/plain";
            await context.HttpContext.Response.WriteAsync(
                "Status code page, status code: " + 
                context.HttpContext.Response.StatusCode);
        });
        //note that order of middlewares is importante 
        //and above should be registered as one of the first middleware and before app.UseMVC()
