    [XmlRoot("foo")]
    public class Foo
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
    static class Program
    {
        static void Main()
        {
            string xml = "<foo id='123'/>";
            object obj;
            using (XmlReader reader = XmlReader.Create(new StringReader(xml)))
            {
                reader.MoveToContent();
                switch (reader.Name)
                {
                    case "foo":
                        obj = new XmlSerializer(typeof(Foo)).Deserialize(reader);
                        break;
                    default:
                        throw new NotSupportedException("Unexpected: " + reader.Name);
                }
            }            
        }
    }
