    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using System.Xml;
    using KeyValue = System.Collections.Generic.KeyValuePair<string, string>;
    
    namespace YourNamespace
    {
        public sealed class KeyValueHandler : IConfigurationSectionHandler
        {
            public object Create(object parent, object configContext, XmlNode section)
            {
                var result = new List<KeyValue>();
                foreach (XmlNode child in section.ChildNodes)
                {
                    var key = child.Attributes["key"].Value;
                    var value = child.Attributes["value"].Value;
                    result.Add(new KeyValue(key, value));
                }
                return result;
            }
        }
    }
