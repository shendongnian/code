    public class ApplicationSettings : IApplicationSettings {
     public int MyOldMagicNumber { 
       get { return ConfigurationManager.AppSettings["MyOldMagicNumber"]; }
      }
    }
    
    public class FakeApplicationSettings : IApplicationSettings {
     public int MyOldMagicNumber { 
       get { return 87; /*Or whatever you want :) */ }
      }
    }
