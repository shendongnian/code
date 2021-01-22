    using System.IO.IsolatedStorage;
    
    public static class AppSettings
    {
        private static IsolatedStorageSettings Settings = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;
            
        public static void StoreSetting(string settingName, string value)
        {
            StoreSetting<string>(settingName, value);
        }
    
        public static void StoreSetting<TValue>(string settingName, TValue value)
        {
            if (!Settings.Contains(settingName))
                Settings.Add(settingName, value);
            else
                Settings[settingName] = value;
            // modified by http://stackoverflow.com/users/373321/stuart - if you don't call Save then WP7 will corrupt your memory!
            Settings.Save()
        }
    
        public static bool TryGetSetting<TValue>(string settingName, out TValue value)
        {            
            if (Settings.Contains(settingName))
            {
                value = (TValue)Settings[settingName];
                return true;
            }
    
            value = default(TValue);
            return false;
        }
    }
