                services.Configure<MvcOptions>(options =>
            {
                using (AsyncScopedLifestyle.BeginScope(container))
                {
                    options.Filters.Add(container.GetRequiredService<MyCustomActionFilter>());
                }
            });
            #region SampleInjector
            IntegrateSimpleInjector(services);
            #endregion
