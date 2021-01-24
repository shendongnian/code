        static void Main(string[] args)
        {
            DATA data = new DATA();
            data.SIGNATURES = new List<SIGNATURE>();
            data.SIGNATURES.Add(new SIGNATURE() { ACTEUR = "", DATE= "", UTILISATEUR= "" });
            data.SIGNATURES.Add(new SIGNATURE() { ACTEUR = "", DATE = "", UTILISATEUR = "" });
            XmlSerializer serializer = new XmlSerializer(typeof(DATA));
            using (TextWriter writer = new StreamWriter(@"Xml.xml"))
            {
                serializer.Serialize(writer, data);
            }
            XmlSerializer deserializer = new XmlSerializer(typeof(DATA));
            TextReader reader = new StreamReader(@"myXml.xml");
            object obj = deserializer.Deserialize(reader);
            DATA XmlData = (DATA)obj;
            reader.Close();
        }
      public class SIGNATURE
        {
            public string UTILISATEUR { get; set; }
            public string ACTEUR { get; set; }
            public string DATE { get; set; }
        }
    
        public class DATA
        {
            public List<SIGNATURE> SIGNATURES { get; set; }
        }
