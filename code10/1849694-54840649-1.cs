    public class AppSettings
    {
       public string UserName
       {
          get => ReadSetting(null);
          set => SaveSetting(value);
       }
    
       private string ReadSetting(string defaultValue,
                                 [CallerMemberName]string settingKey = null)
       {
           var localSettings = ApplicationData.Current.LocalSettings;
           if (localSettings.Values.ContainsKey(settingKey))
           {
                return (string)settings.Values[settingKey];
           }
           else
           {
                return defaultValue;
           }
       }
    
       private string SaveSetting(string value, 
                                 [CallerMemberName]string settingKey = null)
       {
           ApplicationData.Current.LocalSettings.Values[settingKey] = value;
       }
    }
