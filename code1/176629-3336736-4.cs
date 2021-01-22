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
            IProvider retVal = null;
            providerDict.TryGetValue(typeof (providerRequested), out retVal);
            return retVal;
        }
    }
