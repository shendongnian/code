    class Program
    {
        static void Main(string[] args)
        {
            //
            var xml = "<RESPONSE  version=\"1\" ><SOCCER AnotherAttribute =\"1\" /></RESPONSE>";
            var serializer = new XmlSerializer(typeof(Response<int>));
            var result = (Response<int>)serializer.Deserialize(new StringReader(xml));
            xml = "<RESPONSE version=\"10\"><RESULTS MyAttribute = \"1\" /></RESPONSE >";
            result = (Response<int>)serializer.Deserialize(new StringReader(xml));
            Console.ReadLine();
        }
    }
    [XmlRoot("RESPONSE")]
    public class Response<T>
    {
        [XmlAttribute(AttributeName = "version")]
        public T Version { get; set; }
        [XmlElement(ElementName = "SOCCER")]
        public SoccerRoot SoccerRoot { get; set; }
        [XmlElement(ElementName = "RESULTS")]
        public Results Results { get; set; }
    }
    public class SoccerRoot
    {
        [XmlAttribute(AttributeName = "AnotherAttribute")]
        public int AnotherAttribute { get; set; }
    }
    public class Results
    {
        [XmlAttribute(AttributeName = "MyAttribute")]
        public bool MyAttribute { get; set; }
    }
