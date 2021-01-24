    public class Configuration
    {
        [XmlArray("Names")]
        [XmlArrayItem("Names")]
        public List<string> Names { get; set; }
        public Load(Stream stream) 
        {
            var xmlSerializer = new XmlSerializer(typeof(Configuration));
            var config = (Configuration)xmlSerializer.Deserialize(stream);
            return config;
        }
    
    }
