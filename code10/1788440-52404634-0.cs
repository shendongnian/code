    public string GetSetting(string key)
    {
        var value = Environment.GetEnvironmentVariable(key);
    
        if(string.IsNullOrEmpty(value))
        {
            value = ConfigurationManager.AppSettings[key];
        }
    
        return value;
    }
