    public class Key
    {
        [XmlText]
        public bool Value { get; set; }
        [XmlAttribute("name")]
        public string Setting { get; set; }
    }
    [XmlRoot("settings")]
    public class Settings
    {
        [XmlElement("key")]
        public List<Key> Keys { get; set; }
        public Settings()
        {
            Keys = new List<Key>();
        }
    }
    public static void Main(string[] args)
    {
        var xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>    
                    <settings>
                        <key name=""setting_name"">true</key>
                    </settings>";
        var serializer = new XmlSerializer(typeof(Settings));
        Settings result;
        using (TextReader reader = new StringReader(xml))
        {
            result = (Settings)serializer.Deserialize(reader);
        }
        var res = result.Keys.First();
        Console.WriteLine(string.Format("{0}, {1}", res.Setting, res.Value));
    }
