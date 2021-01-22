    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    namespace A
    {
      public class ConfigElement:System.Configuration.ConfigurationElement
    {
        [ConfigurationProperty("url",IsRequired=true) ]
        public string url
        {
            get
            {
                return this["url"] as string;
            }
        }
        [ConfigurationProperty("value", IsRequired = true)]
        public string value
        {
            get
            {
                return this["value"] as string;
            }
        }
      }
    }
