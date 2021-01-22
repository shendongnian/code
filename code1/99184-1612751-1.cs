    public class IoCContainer
    {
      private static ContainerType = null;
      public static ContainerType Instance 
      {
        get 
        {
          if (_container == null)
          {
    	    string configFileName = ConfigurationManager.AppSettings[ConfigFileAppSettingName];
    	    _container = new WindsorContainer(new XmlInterpreter(configFileName));
    	  }
    
          return _container;
        }
      }
    }
