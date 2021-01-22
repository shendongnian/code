    public static class ConfigurationHelper
    {
         public static Get<T>(Settings setting)
         {
             string output = ConfigurationManager.AppSettings[setting.ToString()];
             if(string.isNullOrEmpty(output))
                   throw new ConfigurationErrorsException("Setting " + setting + " is not defined in Configuration file.");
             return (T)output; //You can probably use Convert.* functions. 
         }
    }
