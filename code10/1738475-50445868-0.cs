    namespace SOTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Entitati));
                using (FileStream fileStream = new FileStream("data.xml", FileMode.Open))
                {
                    Entitati result = (Entitati)serializer.Deserialize(fileStream);
    
                    Console.ReadKey();
                }
            }
        }
    
        [XmlRoot("Entitati")]
        public class Entitati
        {
            [XmlElement("Entitate")]
            public List<Entitate> entitati { get; set; }
        }
    
        [XmlRoot("Entitate")]
        public class Entitate
        {
            [XmlElement("nume")]
            public string nume { get; set; }
    
            [XmlElement("actiuni")]
            public int actiuniDisponibile { get; set; }
    
            [XmlElement("valoare")]
            public double valoareActiune { get; set; }
        }
    }
