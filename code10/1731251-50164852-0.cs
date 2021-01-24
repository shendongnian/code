    var webhost = WebHost.CreateDefaultBuilder(args)
                         .UseStartup<Startup>();
    //If not hosted by IIS for auth
    if (String.IsNullOrEmpty(webhost.GetSetting("IIS_HTTPAUTH"))) {
        webhost = webhost.UseHttpSys(options => {
                                options.Authentication.Schemes =  AuthenticationSchemes.NTLM | AuthenticationSchemes.Negotiate;
                                options.Authentication.AllowAnonymous = false;
                           });
    }
    return webhost.Build();
