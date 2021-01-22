    public class XmlAttributeOverridesBuilder
    {
        private Dictionary<Type, Dictionary<string, XmlAttributes>> _entries;
        
        public XmlAttributeOverridesBuilder()
        {
            _entries = new Dictionary<Type, Dictionary<string, XmlAttributes>>();
        }
        
        public void Add(Type type, XmlAttributes attributes)
        {
            Add(type, String.Empty, attributes);
        }
        
        public void Add(Type type, string member, XmlAttributes attributes)
        {
            Dictionary<string, XmlAttributes> typeEntries;
            if (!_entries.TryGetValue(type, out typeEntries))
            {
                typeEntries = new Dictionary<string, XmlAttributes>();
                _entries[type] = typeEntries;
            }
            typeEntries[member] = attributes;
        }
        
        public XmlAttributeOverrides GetOverrides()
        {
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            foreach(var kvpType in _entries)
            {
                foreach(var kvpMember in kvpType.Value)
                {
                    overrides.Add(kvpType.Key, kvpMember.Key, kvpMember.Value);
                }
            }
            return overrides;
        }
        
        public XmlAttributeOverridesBuilder Combine(XmlAttributeOverridesBuilder other)
        {
            // combine logic to build a new XmlAttributeOverridesBuilder
            // ...
        }
    }
