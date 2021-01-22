    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    namespace A
    {
     public class WebConfigSection:ConfigurationSection
     {
        public WebConfigSection()
        {
        }
        [ConfigurationProperty("urlCollection")]
        public ConfigElementCollection allValues
        {
            get
            {
                return this["urlCollection"] as ConfigElementCollection;
            }
        }
        public static WebConfigSection GetConfigSection()
        {
            return ConfigurationSettings.GetConfig("URLSection") as WebConfigSection;
        }
     }
    }
