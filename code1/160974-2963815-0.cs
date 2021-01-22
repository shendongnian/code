    class Program
    {
        static void Main(string[] args)
        {
            var product = new Product() { Name = "PVC SCHOOL" };
            product.Notes = new List<note>();
            product.Notes.Add(new note() { Note = "A" });
            product.Notes.Add(new note() { Note = "B" });
    
            var serialer = new XmlSerializer(typeof(Product));
            using (var stream = new StreamWriter("test.txt"))
            {
                serialer.Serialize(stream, product);
            }
        }
    }
    
    
    public class Product
    {
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlArray("notes")]
        public List<note> Notes { get; set; }
    }
    
    public class note
    {
        [XmlIgnore]
        public string Note { get; set; }
    }
