    [XmlRoot("Doc")]
    public class MyDoc : IXmlSerializable
    {
        [XmlArray("Items")]
        public List<Item> Items { get; set; }
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            Items = new List<Item>();
            reader.ReadToFollowing("Items");
            using (var innerReader = reader.ReadSubtree())
            {
                innerReader.MoveToContent();
                while (innerReader.Read())
                {
                    if (innerReader.IsStartElement())
                    {
                        var item = new Item { Name = innerReader.Name };
                        Items.Add(item);
                    }
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
    public class Item
    {
        public string Name { get; set; }
    }
