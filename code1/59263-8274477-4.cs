    <configSections>
        <section name="cachingConfiguration" type="Microsoft.Practices.EnterpriseLibrary.Caching.Configuration.CacheManagerSettings, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" requirePermission="true" />
      </configSections>
    
    
      <cachingConfiguration defaultCacheManager="Cache Manager">
        <cacheManagers>
          <add name="MemoryCache" type="Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
            expirationPollFrequencyInSeconds="60" maximumElementsInCacheBeforeScavenging="1000"
            numberToRemoveWhenScavenging="10" backingStoreName="NullBackingStore" />
          <add name="DiskCache" type="Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
            expirationPollFrequencyInSeconds="60" maximumElementsInCacheBeforeScavenging="1000"
            numberToRemoveWhenScavenging="10" backingStoreName="IsolatedStorageCacheStore" />
        </cacheManagers>
        <backingStores>
          <add type="Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.NullBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
            name="NullBackingStore" />
          <add name="IsolatedStorageCacheStore" type="Microsoft.Practices.EnterpriseLibrary.Caching.BackingStoreImplementations.IsolatedStorageBackingStore, Microsoft.Practices.EnterpriseLibrary.Caching, Version=5.0.414.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
            encryptionProviderName="" partitionName="MyCachePartition" />
        </backingStores>
      </cachingConfiguration>
