        public class Thingie
        {
            [XmlElement("name")]
            public string Name { get; set; }
        }
        [XmlRoot]
        public class ArrayOfThingie
        {
            [XmlAttribute("version")]
            public string Version { get; set; }
            [XmlElement("Thingie")]
            public Thingie[] Thingies { get; set; }
        }
        static void Main(string[] args)
        {
            Thingie[] thingies = new[] { new Thingie { Name = "one" }, new Thingie { Name = "two" } };
            ArrayOfThingie at = new ArrayOfThingie { Thingies = thingies, Version = "1.0" };
            XmlSerializer serializer = new XmlSerializer(typeof(ArrayOfThingie));
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, at);
            Console.WriteLine(writer.ToString());
        }
