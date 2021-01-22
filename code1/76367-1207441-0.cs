    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
            var xml = 
    @"<Configuration>
        <Config name=""SendToAddresses"">some value</Config>
        <Config name=""CCToAddresses""></Config>
        <Config name=""BCCAddresses""></Config>
      </Configuration>";
            using (var reader = new StringReader(xml))
            {
                var configuration = (Configuration)serializer.Deserialize(reader);
            }
        }
    }
    public class Configuration
    {
        [XmlElement(ElementName="Config")]
        public Config[] Configs { get; set; }
    }
    public class Config
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
