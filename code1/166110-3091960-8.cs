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
                string _section = "DevModeSettings/" + devMode;
    
                ConfigurationManager.RefreshSection(_section); // This must be done to flush out previous overrides
                DevModeSetting config = (DevModeSetting)ConfigurationManager.GetSection(_section);
    
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
