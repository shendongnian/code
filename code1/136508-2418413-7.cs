    // wrapper class for global settings singleton
    public class Settings : ISettings
    {
         public string CultureName 
         {
             get { return GlobalSettings.Instance.CultureName; }
         }
    }
    // elsewhere in code
    public LocalizedContent GetLocalizedContent ()
    {
        LocalizedContent content = new LocalizedContent (new Settings ());
        return content;
    }
