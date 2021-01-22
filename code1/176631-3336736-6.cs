    public IProvider ProviderFactoryMethodHere(Type providerRequested)
    {
        Dictionary <Type, IProvider> providerDict;
        if (providerDict == null)
        {
          // populate dictionary with providers, keyed by their type
          providerDict = new Dictionary<Type, IProvider>();
          providerDict.Add(typeof(Provider1), new Provider1());
    
          // repeat for all providers, this is pretty simple but definitely works
          // we could use other ways of holding on to your provider instances
        }
        if (providerDict.HasKey(providerRequested))
        {
            return providerDict[providerRequested];
        }
        // could throw exception here if you want to use that kind of error
        // handling, but we'll just return null for now
        return null;
    }
