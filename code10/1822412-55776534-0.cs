    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        options => {
                            options.LoginPath = "/Login";
                        }
                    );
