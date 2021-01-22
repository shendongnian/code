    public static class SettingsExtensions
    {
        public static bool TryGetValue<T>(this Settings settings, string key, out T value)
        {
            if (settings.Properties[key] != null)
            {
                value = (T) settings[key];
                return true;
            }
            value = default(T);
            return false;
        }
        public static bool ContainsKey(this Settings settings, string key)
        {
            return settings.Properties[key] != null;
        }
        public static void SetValue<T>(this Settings settings, string key, T value)
        {
            if (settings.Properties[key] == null)
            {
                var p = new SettingsProperty(key)
                {
                    PropertyType = typeof(T),
                    Provider = settings.Providers["LocalFileSettingsProvider"],
                    SerializeAs = SettingsSerializeAs.Xml
                };
                p.Attributes.Add(typeof(UserScopedSettingAttribute), new UserScopedSettingAttribute());
                var v = new SettingsPropertyValue(p);
                settings.Properties.Add(p);
                settings.Reload();
            }
            settings[key] = value;
            settings.Save();
        }
    }
