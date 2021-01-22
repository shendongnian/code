    [XmlRoot("product")]
    public class Product
    {
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("note")]
        public List<Note> ListNotes { get; set; }
    }
    
    public class Note
    {
        [XmlText]
        public string Text { get; set; }
    }
    
    class Program
    {
        public static void Main()
        {
            var p = new Product
            {
                Name = "2 1/2 X 6 PVC NIPPLE TOE SCH  80",
                ListNotes = new List<Note>
                {
                    new Note { Text = "!--note 1---" },
                    new Note { Text = "!--note 2---" },
                }
            };
            var serializer = new XmlSerializer(p.GetType());
            serializer.Serialize(Console.Out, p);
        }
    }
