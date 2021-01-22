    public class IoCContainer
    {
      public static ContainerType Instance 
      {
        get 
        {
          if (_container == null)
          {
    	    string configFileName = ConfigurationSettings.AppSettings[ConfigFileAppSettingName];
    	    _container = new WindsorContainer(new XmlInterpreter(configFileName));
    	  }
    
          return _container;
        }
      }
    }
