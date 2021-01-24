        var providers = Configuration.GetSection("X").Get<X>();
        foreach (var provider in providers.Providers)
        {
            if (provider.IsDefaultProvider == true)
            {
                //var _defaultProvider = (XProviderType)Enum.Parse(typeof(XProviderType), provider.Value.ToString());
            }
        }
