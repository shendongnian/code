    public static class SettingsPropertyCollectionExtensions
    {
        public static T GetDefault<T>(this SettingsPropertyCollection me, string property)
        {
            string val_string = (string)Settings.Default.Properties[property].DefaultValue;
            return (T)Convert.ChangeType(val_string, typeof(T));
        }
    }
