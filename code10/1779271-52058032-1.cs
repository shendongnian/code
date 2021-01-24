    public class Value : IValue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public XmlSchema GetSchema() => null;
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Name = reader.GetAttribute("Name");
            Id = int.Parse(reader.GetAttribute("Id"));
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Id", Id.ToString());
            writer.WriteAttributeString("Name", Name);
        }
    }
