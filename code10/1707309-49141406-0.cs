                WindsorContainer.Register(Component.For<Service.IPlanService>()
                .AsWcfClient()
                .LifestyleTransient()
                .DependsOn((k, d) =>
                {
                    d["EndPoint"] = WcfEndpoint.BoundTo(new WebHttpBinding(WebHttpSecurityMode.Transport) { MaxReceivedMessageSize = 2147483647 })
                                                      .At(new Uri(ServiceCount % 2 == 0 ? ClientAccountsUriImpact : ClientAccountsUriProd, "plans"))
                                                      .AddExtensions(new WebHttpBehavior())
                                                      .AddExtensions(new ClientCredentialsEndPointBehaviour(ClientId, ClientSecret, ClientAccountsAudience, Issuer));
                    if (ServiceCount % 2 == 0)
                        ServiceCount = 1;
                    else
                        ServiceCount = 0;
                } )
                .Interceptors(new Castle.Core.InterceptorReference(typeof(MyCacheInterceptor))).Anywhere
                );
