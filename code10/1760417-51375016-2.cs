    public class List : ConfigurationElement, IXmlSerializable
    {
        public List()
        { }
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)(this["name"]); }
            set { this["name"] = value; }
        }
        [ConfigurationProperty("", IsRequired = false, IsKey = false,
      IsDefaultCollection = true)]
        public KeyValueConfigurationCollection Items
        {
            get
            {
                var items = base[""] as KeyValueConfigurationCollection;
                return items;
            }
            set
            {
                if (base.Properties.Contains("items"))
                {
                    base["items"] = value;
                }
                else
                {
                    var configProperty = new ConfigurationProperty("items", typeof(KeyValueConfigurationCollection), value);
                    base.Properties.Add(configProperty);
                }
            }
        }
        public XmlSchema GetSchema()
        {
            return this.GetSchema();
        }
        public void ReadXml(XmlReader reader)
        {
            this.DeserializeElement(reader, false);
        }
        public void WriteXml(XmlWriter writer)
        {
            this.SerializeElement(writer, false);
        }
        public static List Deserialize(string xml)
        {
            List list = null;
            var serializer = new XmlSerializer(typeof(List), new XmlRootAttribute("list"));
            var xdoc = XDocument.Parse(xml);
            list = (List)serializer.Deserialize(xdoc.CreateReader());
            return list;
        }
    }
