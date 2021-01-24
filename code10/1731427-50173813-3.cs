    class Program
    {
        static void Main()
        {
            using (var reader = XmlReader.Create("my.xml"))
            {
                var ser = new XmlSerializer(typeof(Product));
                while(reader.Read())
                {
                    if(reader.NodeType == XmlNodeType.Element 
                        && reader.Name == "product"
                        && reader.NamespaceURI == "http://www.drugbank.ca")
                    {
                        using (var subReader = reader.ReadSubtree())
                        {
                            var obj = (Product)ser.Deserialize(subReader);
                            Console.WriteLine(obj.Name);
                        }
                    }
                }
            }
        }
    }
    [XmlRoot("product", Namespace = "http://www.drugbank.ca")]
    public class Product
    {
        [XmlElement("name", Namespace = "http://www.drugbank.ca")]
        public string Name { get; set; }
    }
