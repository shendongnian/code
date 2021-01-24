    services.AddAuthorization(config =>
    {
        config.AddPolicy("View", p => p.RequireAssertion(context =>
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            Console.WriteLine(filterContext.HttpContext.Request.Method);
            return true; // add your custom condition
        }));
        config.AddPolicy("Edit", p => p.RequireAssertion(context =>
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            Console.WriteLine(filterContext.HttpContext.Request.Method);
            return true; // add your custom condition
        }));
    });
