    services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
                services.AddScoped<IUrlHelper>(factory =>
                {
                    var actionContext = factory.GetService<IActionContextAccessor>()
                                               .ActionContext;
                    return new UrlHelper(actionContext);
                });
