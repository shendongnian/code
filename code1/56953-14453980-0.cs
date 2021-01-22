    public class EmailTextElement : ConfigurationElement {
    
        public string Value { get; private set; }
    
        protected override void DeserializeElement(XmlReader reader, bool s) {
            Value = reader.ReadElementContentAs(typeof(string), null) as string;
        }
    
    }
