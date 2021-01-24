    .UseStartup<Startup>()
                .UseKestrel()
                .UseHttpSys(options =>
                {
                    options.Authentication.Schemes = AuthenticationSchemes.NTLM;
                    options.Authentication.AllowAnonymous = false;
                    options.MaxConnections = 1000;
                })
                .UseIISIntegration()
