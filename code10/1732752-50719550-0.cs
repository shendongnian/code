            app.Use(async (context, next) =>
            {
                if (!context.User.Identity.IsAuthenticated)
                {
                    await context.ChallengeAsync("oidc");
                }
                else
                {
                    await next();
                }
            });
