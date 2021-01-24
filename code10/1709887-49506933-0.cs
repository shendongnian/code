    app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    ExpireTimeSpan = TimeSpan.FromHours(1),
                    SlidingExpiration = true,
                    CookieHttpOnly = true,
                    CookieName = "App.Authentication",
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
