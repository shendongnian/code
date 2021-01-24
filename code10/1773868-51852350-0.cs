            app.MapWhen(context => context.Request.Path.Equals("/sensitiveOperation") && context.Request.Method.Equals(HttpMethods.Put), subApp =>
            {
                subApp.Run(async (context) =>
                {
                    var authService = context.RequestServices.GetRequiredService<IAuthorizationService>();
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        //await context.ChallengeAsync("Windows"); //Option1
                        //await context.ChallengeAsync();  //Option2
                        await context.ChallengeAsync(HttpSysDefaults.AuthenticationScheme); //Option3
                    }
                    if (context.User.Identity.Name == "admin")
                    {
                        await context.Response.WriteAsync("Performing sensitive operation.");
                        // .. Do Sensitive operation....
                    }
                });
            });
