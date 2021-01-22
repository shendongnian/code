    class Program
    {
        static void Main()
        {
            string xml = File.ReadAllText("feed.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(MyType));
            var obj = (MyType)serializer.Deserialize(new StringReader(xml));
        }
    }
    [XmlRoot("feed", Namespace = "http://www.w3.org/2005/Atom")]
    public class MyType
    {
        [XmlElement("id")]
        public string Id { get; set; }
        [XmlElement("updated")]
        public DateTime Updated { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
    }
