    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => {
            options.Events.OnRedirectToAccessDenied = context => {
                 context.Response.StatusCode = 403;
            };
        });
