    services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
 
                })
                .AddJwtBearer(cfg =>
                {
                     //standard settings
                })
                .AddCookie(AuthTypes.CLIENT_AUTHENTICATION_TYPE, cfg =>
                    {
                        //cookie settings; the most important is following event:
                        cfg.Events.OnValidatePrincipal = (CookieValidatePrincipalContext ctx) =>
                        {
                            ClaimsPrincipal mainUser = ctx.HttpContext.User; //get ClaimsPrincipal from JwtBearer
                            ClaimsPrincipal cookieUser = ctx.Principal; //get ClaimsPrincipal read from Cookie
 
                            Debug.Assert(mainUser.Identities.Count() == 1);
 
                            //now we have to add ClaimsIdentity to main ClaimsPrincipal (from JwtBearer). We add only those absent in main ClaimsPrincipal (here is simplified solution) 
                            var claimsToAdd = cookieUser.Identities.Where(id => id.AuthenticationType != mainUser.Identities.ElementAt(0).AuthenticationType);
                            mainUser.AddIdentities(claimsToAdd);
                            return Task.CompletedTask;
                        };
                    }
 
                );
