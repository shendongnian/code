    public class ModuleSection : ConfigurationSection
    {
        private const string ELEMENT_NAME_CONFIG = "config";
        private XmlNode _configNode;
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        public XmlNode Config
        {
            get { return _configNode; }
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            if(elementName.Equals(ELEMENT_NAME_CONFIG, StringComparison.Ordinal)) {
                // Add the unrecognized element.
                _configNode = _xmlDocument.ReadNode(reader);
                return true;
            } else {
                return base.OnDeserializeUnrecognizedElement(elementName, reader);
            }
        }
    }
