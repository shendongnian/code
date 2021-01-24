      app.Map(
                "/identity",
                coreApp =>
                    {
                        var factory =
                            new IdentityServerServiceFactory()
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());
                        factory.ViewService = new Registration<IViewService, IdentityCustomViewService>();
                        factory.Register(new Registration<CustomIdentityDbContext>(resolver => HttpContext.Current.GetOwinContext().Get<CustomIdentityDbContext>()));
                        factory.Register(new Registration<CustomUserManager>(resolver => HttpContext.Current.GetOwinContext().GetUserManager<CustomUserManager>()));
                        factory.Register(new Registration<CustomAspNetIdentityUserService>(x => new CustomAspNetIdentityUserService(x.Resolve<CustomUserManager>())));
                        factory.Register(new Registration<UserManager<CustomIdentityUser, int>>(x => x.Resolve<CustomUserManager>()));
                        factory.UserService = new Registration<IUserService>(x => x.Resolve<CustomAspNetIdentityUserService>());
                        coreApp.UseIdentityServer(
                            new IdentityServerOptions
                            {
                                SiteName = "Identity Server",
                                SigningCertificate = Cert.Load(),
                                Factory = factory,
                                RequireSsl = true,
                                AuthenticationOptions = new IdentityServer3.Core.Configuration.AuthenticationOptions
                                {
                                    IdentityProviders= ConfigureIdentityProviders,
                                    EnablePostSignOutAutoRedirect = true,
                                    CookieOptions = new IdentityServer3.Core.Configuration.CookieOptions()
                                    {
                                        AllowRememberMe = true,
                                        SecureMode = CookieSecureMode.Always,
                                        RememberMeDuration = TimeSpan.FromDays(30),
                                        IsPersistent = false,
                                        Path = "/"
                                    },
                                }
                            });
                       
                    });
