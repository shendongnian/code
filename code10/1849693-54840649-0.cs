    public class AppSettings
    {
       public string UserName
       {
          get => ReadSetting("");
          set => SaveSetting(value);
       }
    
       private string ReadSetting(string defaultValue,
                                 [DisplayMemberName]string settingKey = null)
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
                                 [DisplayMemberName]string settingKey = null)
       {
           ApplicationData.Current.LocalSettings.Values[settingKey] = value;
       }
    }
