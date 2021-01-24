    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
    {
        o.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = c =>
            {
                var svc = c.HttpContext.RequestServices.GetRequiredService<IMyService>();
                c.NoResult();
                c.Response.StatusCode = 500;
                c.Response.ContentType = "text/plain"; c.Response.WriteAsync(c.Exception.ToString()).Wait();
                return Task.CompletedTask;
            }
        };
    });
