       AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
       LoginPath = new PathString("/Account/Login"),
       Provider = new CookieAuthenticationProvider
       {
          OnApplyRedirect = ctx =>
          {
             if (!IsAjaxRequest(ctx.Request))
             {
                ctx.Response.Redirect(ctx.RedirectUri);
             }
         }
       }
    });
