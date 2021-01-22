    public class ModuleElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true)]
        public string Name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        XElement _config;
        public XElement Config
        {
            get { return _config;  }
        }
        protected override bool OnDeserializeUnrecognizedElement(string elementName, System.Xml.XmlReader reader)
        {
            if (elementName == "config")
            {
                _config = (XElement)XElement.ReadFrom(reader);
                return true;
            }
            else
                return base.OnDeserializeUnrecognizedElement(elementName, reader);
        }
    }
