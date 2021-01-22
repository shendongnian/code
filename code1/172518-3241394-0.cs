    public CachedSnmpDataSource : ISnmpDataSource
    {
      private DateTime m_lastRetrieved;
      private TimeSpan m_cacheExpiryPeriod;
      private List<string> m_hostIpAddresses;
      private Func<SnmpDataSource> m_dataSourceCreator
    
      public CachedSnmpDataSource(Func<SnmpDataSource> dataSourceCreator, TimeSpan cacheExpiryPeriod)
      {
          m_dataSourceCreator = dataSourceCreator;
          m_cacheExpiryPeriod = cacheExpiryPeriod;
      }
    
      public List<string> HostIpAddresses
      {
        get
        {
           if(!IsRecentCachedVersionAvailable()) 
           {
               CreateCachedVersion();
           }
           return new List<string>(m_hostIpAddresses);
        } 
    
        private bool IsRecentCachedVersionAvailable()
        {
            return m_hostIpAddresses != null && 
                   (DateTime.Now - m_lastRetrieved) < m_cacheExpiryPeriod;
        }
    
        private void CreateCachedVersion()
        {  
           SnmpDataSource dataSource = m_dataSourceCreator();
           m_hostIpAddresses = dataSource.HostIpAddresses;
           m_lastRetrieved = DateTime.Now;       
        }
      }
    
      ...
    }
