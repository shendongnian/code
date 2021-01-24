    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                string data = File.ReadAllText("D://pleasecheckXML.txt");
                XmlSerializer xmldata = new XmlSerializer(typeof(Note));
                byte[] byteArray = Encoding.ASCII.GetBytes(data);
                MemoryStream stream = new MemoryStream(byteArray);
                var datafromxml = xmldata.Deserialize(stream);
            }
        }
    
        [XmlRoot(ElementName = "note")]
        public class Note
        {
            [XmlElement(ElementName = "to")]
            public string To { get; set; }
            [XmlElement(ElementName = "from")]
            public string From { get; set; }
            [XmlElement(ElementName = "heading")]
            public List<object> Heading { get; set; }
            [XmlElement(ElementName = "body")]
            public string Body { get; set; }
        }
    
    }
