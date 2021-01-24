        .AddCookie(options =>
             {
                 options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                 options.Cookie.Name = "mvchybridautorefresh";
                  options.LoginPath = new PathString("/Account/Login"); //please provide your login/logout path
                  options.LogoutPath = new PathString("/Account/Logout");
                 options.Events.OnRedirectToLogin = context =>
                 {
                     if (IsAjaxRequest(context.Request))
                     {
                         context.Response.Headers["Location"] = context.RedirectUri;
                         context.Response.StatusCode = 401;
                     }
                     else
                     {
                         context.Response.Redirect(context.RedirectUri);
                     }
                     return Task.CompletedTask;
                 };
                 
             })
