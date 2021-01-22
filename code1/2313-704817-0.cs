    public class MyXmlCustomConfigSection : MyCustomConfigSection
    {
        public MyXmlCustomConfigSection (string configXml)
        {
            XmlTextReader reader = new XmlTextReader(new StringReader(configXml));
            DeserializeSection(reader);
        }
    }
