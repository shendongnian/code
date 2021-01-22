    public class ModuleSection : ConfigurationSection
    {
        private const string ROOT_ELEMENT_NAME = "module";
        private const string ELEMENT_NAME_CONFIG = "config";
        private XmlDocument _xmlDocument;
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        public XmlNode Config
        {
            get { return _xmlDocument.SelectSingleNode(String.Format("//{0}", ELEMENT_NAME_CONFIG)); }
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, XmlReader reader)
        {
            if (_xmlDocument == null)
            {
                _xmlDocument = new XmlDocument();
                // Write down the XML declaration.
                XmlDeclaration xmlDeclaration = _xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
                // Create the root element.
                XmlElement rootNode = _xmlDocument.CreateElement(ROOT_ELEMENT_NAME);
                _xmlDocument.InsertBefore(xmlDeclaration, _xmlDocument.DocumentElement);
                _xmlDocument.AppendChild(rootNode);
            }
            
            // Add the unrecognized element.
            XmlNode _xmlNode = _xmlDocument.ReadNode(reader);
            _xmlDocument.DocumentElement.AppendChild(_xmlNode);
            return true;
        }
    }
