    services.AddAuthentication(options =>
     {
         options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
         options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    
      })
     .AddJwtBearer(options =>
     {
         options.TokenValidationParameters = tokenValidationParameters;
    
     })
     .AddFacebook(facebookOptions =>
     {
         facebookOptions.AppId = "";
         facebookOptions.AppSecret = "";
         facebookOptions.SaveTokens = true;
         facebookOptions.Scope.Add("email");
         facebookOptions.Scope.Add("user_birthday");
         facebookOptions.Scope.Add("user_gender");
         facebookOptions.Scope.Add("user_posts");
         facebookOptions.Scope.Add("manage_pages");
         facebookOptions.Scope.Add("publish_pages");
     })
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
