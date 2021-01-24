        if (bool.Parse(configuration["Authentication:Google:IsEnabled"]))
        {
            var externalAuthConfiguration = IocManager.Resolve<IExternalAuthConfiguration>();
            externalAuthConfiguration.Providers.Add(
                new ExternalLoginProviderInfo(
                    GoogleAuthProviderApi.Name,
                    configuration["Authentication:Google:ClientId"],
                    configuration["Authentication:Google:ClientSecret"],
                    typeof(GoogleAuthProviderApi)
                )
            );
        }
