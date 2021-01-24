    .AddCookie(opts =>
            {
                opts.AccessDeniedPath = "/Account/AccessDenied";
                opts.LoginPath = "/Account/SignIn";
                opts.Cookie.HttpOnly = true;
                opts.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                opts.SessionStore = authSessionStore;
                opts.Cookie.Path = "/api";
                opts.Cookie.IsEssential = true;
            });
