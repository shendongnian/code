    [SettingsProvider(typeof(FileSettingsProvider))]
    internal sealed partial class Settings: ApplicationSettingsBase {
        private static Settings defaultInstance = (Settings)ApplicationSettingsBase.Synchronized(new Settings())));
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        public T GetDefaultValue<T>(string setting) {
            try {
                if (typeof(T) != typeof(string))
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromString((string)this.Properties[setting].DefaultValue);
                else
                    return (T)this.Properties[setting].DefaultValue;
            }
            catch {
                return default(T);
            }
        }
        
        [UserScopedSetting()]
        [DefaultSettingValue("512")]
        public int Delay {
            get {
                return ((int)(this["Delay"]));
            }
            set {
                this["Delay"] = value;
            }
        }
    }
