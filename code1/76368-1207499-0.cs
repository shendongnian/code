        [XmlRoot("Configuration")]
        public class Configuration
        {
            [XmlElement("Config")]
            public List<Config> Configs { get; set; }
        }
        public class Config
        {
            [XmlAttribute("name")]
            public string Name { get; set; }
            [XmlText]
            public string Value { get; set; }
            public Config() { }
        }
        // ...
        XmlSerializer s = new XmlSerializer(typeof(Configuration));
        Configuration conf = (Configuration)s.Deserialize(new StringReader("INSERTXMLHERE"));
        foreach (var config in conf.Configs)
        {
            Console.WriteLine("{0} = {1}", config.Name, config.Value);
        }
