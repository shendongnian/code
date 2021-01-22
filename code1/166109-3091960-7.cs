     using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Configuration;
    namespace DevModeDependencyTest
    {
        public class DevModeSetting : ConfigurationSection
        {
            public override bool IsReadOnly()
            {
                return false;
            }
    
            [ConfigurationProperty("webServiceUrl", IsRequired = false)]
            public string WebServiceUrl
            {
                get
                {
                    return (string)this["webServiceUrl"];
                }
                set
                {
                    this["webServiceUrl"] = value;
                }
            }
        }
    }
