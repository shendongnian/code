    public IEnumerable<SettingValue> GetSettingsWithDefaults( IEnumerable<Setting> settings )
    {
        return from s in settings
               join us in this.UserSettings
                 on s.ID equals us.SettingID into userSettings
               from us in userSettings.DefaultIfEmpty()
               select new SettingValue
                      {
                          Setting = s,
                          Value = ( us == null ) ? s.Default : us.Value,
                          IsDefault = ( us == null )
                      };
    }
