    public interface IFooSettings
    {
      int MySettings{get;}
    }
    
    public class ApplicationSettings : IFooSettings
    {
      public string MySettings{get; private set;}
    ApplicationSettings()
    {
     MySettings = ConfigurationManager.AppSettings["mySetting"];
    
    }
    }
