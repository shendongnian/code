    public MyConfigurationProvider : IMyconfigurationProvider
    {
      
      public MyImmutabble ConfigurationValue
      {
        get
        {
          var configurationvalue = (MyObject) ConfigurationManager.GetSection("mySection");
          return new MyImmutable(configurationvalue.ConfigurationValue);
        }
      }
    }
