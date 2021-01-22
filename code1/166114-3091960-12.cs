     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    
    namespace DevModeDependencyTest
    {
        public class DevModeSettingsHandler
        {
            public static DevModeSetting GetDevModeSetting()
            {
                return GetDevModeSetting("debug");
            }
    
            public static DevModeSetting GetDevModeSetting(string devMode)
            {
                string section = "DevModeSettings/" + devMode;
    
                ConfigurationManager.RefreshSection(section); // This must be done to flush out previous overrides
                DevModeSetting config = (DevModeSetting)ConfigurationManager.GetSection(section);
    
                if (config != null)
                {
                    // Perform validation etc...
                }
                else
                {
                    throw new ConfigurationErrorsException("oops!");
                }
    
                return config;
            }
        }
    }
