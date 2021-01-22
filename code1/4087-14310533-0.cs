    using System;
    using System.Configuration;
    
    namespace YourApplication.Extensions
    {
        public static class ExtensionsApplicationSettingsBase
        {
            public static void LoadDefaults(this ApplicationSettingsBase that)
            {
                foreach (SettingsProperty settingsProperty in that.Properties)
                {
                    that[settingsProperty.Name] =
                        Convert.ChangeType(settingsProperty.DefaultValue,
                                           settingsProperty.PropertyType);
                }
            }
        }
    }
