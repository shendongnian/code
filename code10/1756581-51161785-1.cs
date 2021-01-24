    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = File.ReadAllText("D://readjson.txt");
    
                XmlSerializer xml = new XmlSerializer(typeof(Doc));
                byte[] byteArray = Encoding.ASCII.GetBytes(data);
                MemoryStream stream = new MemoryStream(byteArray);
                var obj=xml.Deserialize(stream);
            }
        }
        [XmlRoot(ElementName = "Foo")]
        public class Foo
        {
            [XmlAttribute(AttributeName = "A")]
            public string A { get; set; }
        }
    
        [XmlRoot(ElementName = "Bar")]
        public class Bar
        {
            [XmlAttribute(AttributeName = "A")]
            public string A { get; set; }
        }
    
        [XmlRoot(ElementName = "Items")]
        public class Items
        {
            [XmlElement(ElementName = "Foo")]
            public Foo Foo { get; set; }
            [XmlElement(ElementName = "Bar")]
            public Bar Bar { get; set; }
        }
    
        [XmlRoot(ElementName = "Doc")]
        public class Doc
        {
            [XmlElement(ElementName = "Items")]
            public Items Items { get; set; }
        }
    }
