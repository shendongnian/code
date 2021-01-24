    using Plugin.Settings;
    using Plugin.Settings.Abstractions;
    public static class Settings {
       static ISettings AppSettings { get { return CrossSettings.Current; } }
       public static string MySetting {
          get => AppSettings.GetValueOrDefault("MySettingKey", LastUsedDefault);
          set => AppSettings.AddOrUpdateValue("MySettingKey", value);
       }
    }
