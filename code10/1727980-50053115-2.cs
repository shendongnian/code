    private static void AddCookie(CookieAuthenticationOptions options)
    {
        options.Cookie.Name = "mgame";
        options.AccessDeniedPath = "/Authorization/AccessDenied";                           // Redirect to custom access denied page when user get access is denied
        options.Cookie.HttpOnly = true;                                                     // Prevent cookies from being accessed by malicius javascript code
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;                            // Cookie only will be sent over https
        options.ExpireTimeSpan = TimeSpan.FromMinutes(Constants.CookieTokenExpireTimeSpan); // Cookie will expire automaticaly after being created and the client will redirect back to Identity Server
    }
