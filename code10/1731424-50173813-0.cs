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
                        && reader.NamespaceURI == "")
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
    [XmlRoot("product")]
    public class Product
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
