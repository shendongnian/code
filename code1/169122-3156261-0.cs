    private void StoreSetting(string key, string value)
    {
       IsolatedStorageSettings.ApplicationSettings[key] = value;
    }
    private string GetSetting(string key)
    {
       return IsolatedStorageSettings.ApplicationSettings[key];
    }
