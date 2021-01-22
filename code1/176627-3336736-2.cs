    public IProvider ProviderFactoryMethodHere(Type providerRequested)
    {
        Dictionary <Type, IProvider> providerDict;
        if (providerDict == null)
        {
          // populate dictionary with providers, keyed by their type
          providerDict = new Dictionary<Type, IProvider>();
          providerDict.Add(typeof(Provider1, new Provider1());
    
          // repeat for all providers, this is pretty simple, we could use other methods
        }
        if (providerDict.HasKey(providerRequested))
        {
            IEnumerable retVal = null;
            providerDict.TryGetValue(typeof (object), out retVal);
            return retVal;
        }
    }
