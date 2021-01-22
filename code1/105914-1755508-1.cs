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
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Configuration;
    namespace A
    {
      public class ConfigElementCollection:ConfigurationElementCollection
     {
        public ConfigElement this[int index]
        {
            get
            {
                return base.BaseGet(index) as ConfigElement;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigElement)(element)).url;
        }
     }
    }
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
