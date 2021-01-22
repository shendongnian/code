&lt;?xml version="1.0" encoding="utf-8"?&gt;
&lt;cachingConfiguration defaultCacheManager="Default Cache Manager"&gt;
    &lt;backingStores&gt;
        &lt;add name="inMemory" type="Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.NullBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching" /&gt;
	&lt;/backingStores&gt;
	&lt;cacheManagers&gt;
		&lt;add name="Default Cache Manager" expirationPollFrequencyInSeconds = "60" maximumElementsInCacheBeforeScavenging ="50" numberToRemoveWhenScavenging="10" backingStoreName="inMemory" /&gt;
	&lt;/cacheManagers&gt;
&lt;/cachingConfiguration&gt;
