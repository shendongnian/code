    .AddCookie(options =>
                {
                    options.Cookie.Path = "/";
                    options.SlidingExpiration = false;
                    options.Cookie.SameSite = SameSiteMode.None;
                    options.Cookie.Expiration = TimeSpan.FromMinutes(Global.MAX_LOGIN_DURATION_MINUTES);
                })
