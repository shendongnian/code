    ...
    // Here added my application services. 
    .......
    services.ConfigureApplicationCookie(options => 
    {
         options.Cookie.HttpOnly = true;
         options.Cookie.Expiration = TimeSpan.FromDays(5);
         options.LoginPath = "/Account/Login";
     });
