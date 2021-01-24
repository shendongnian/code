    public Settings SettingsConverter(IDictionary<string, string> data)
    {
         return new Settings
         {
             Enabled = data["ENABLED"],
             ...
         };
    }
