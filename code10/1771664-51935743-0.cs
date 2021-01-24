    services.AddAuthentication(options =>
                {....      })
           .AddOAuth("GitHub", options =>
                {
                  options.ClientId = Configuration["GitHub:ClientId"];
                  options.ClientSecret = Configuration["GitHub:ClientSecret"];
                  options.CallbackPath = new PathString("/signin-github");
                }
