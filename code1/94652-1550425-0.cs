    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Xml.Serialization;
    
    public static class XmlSerializerCache
    {
        private static Dictionary<string, XmlSerializer> cache = new Dictionary<string, XmlSerializer>();
    
        public static XmlSerializer Create(Type type, XmlRootAttribute root)
        {
            string key = String.Format(CultureInfo.CurrentCulture, "{0}:{1}", type.ToString(), root.ElementName);
    
            if (!cache.ContainsKey(key))
            {
                cache.Add(key, new XmlSerializer(type, root));
            }
    
            return cache[key];
        }
    }
