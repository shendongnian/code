    app.Use(async (context, next) =>
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        if (context.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                        {
                            // webapp will then do a location.reload() which triggers the auth
                            context.Response.StatusCode = 401;
                        }
                        else
                        {
                            string auth = context.Request.Headers["Authorization"];
                            if (string.IsNullOrEmpty(auth) || !auth.StartsWith("Bearer ", System.StringComparison.OrdinalIgnoreCase))
                            {
                                await context.ChallengeAsync();
                            }
                            else
                            {
                                await next();
                            }
                        }  
                    }
                    else
                    {
                        await next();
                    }
                });
