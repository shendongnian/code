      public const string DefaultConfigPath = "./config.xml";
    
      protected static MyConfiguration _current;
      public static MyConfiguration Current
      {
        get
        {
          if (_current == null)
            Load(DefaultConfigPath);
          return _current;
        }
      }
    
      public static MyConfiguration Load(string path)
      {
        // Do your loading here
        _current = loadedConfig;
        return loadedConfig; 
      }
    
      // Static save function
    
      //*********** Non-Static Members *********//
    
      public string MyVariable { get; set; }
      // etc..
    }
