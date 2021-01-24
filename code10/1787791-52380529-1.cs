    services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.Cookie.Name = options.CookieName;
                    o.Cookie.Domain = options.CookieDomain;
                    o.SlidingExpiration = true;
                    o.ExpireTimeSpan = options.CookieLifetime;
                    o.TicketDataFormat = ticketFormat;
                    o.CookieManager = new CustomChunkingCookieManager();
                });
