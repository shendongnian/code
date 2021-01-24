        public static string filepath = "test.xml";
        static void Main(string[] args)
        {
            Serialize();
            Console.WriteLine(Deserialize().Test);
            Console.ReadKey(true);
        }
        private static XmlConfig Deserialize()
        {
            XmlConfig result = null;
            XmlSerializer serializer = new XmlSerializer(typeof(XmlConfig));
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    result = (XmlConfig)serializer.Deserialize(sr);
                }
            }
            return result;
        }
        private static void Serialize()
        {
            using (FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(XmlConfig));
                serializer.Serialize(fs, new XmlConfig());
            }
        }
    }
    public class XmlConfig
    {
        public string Test { get; set; } = "Teststring";
    }
