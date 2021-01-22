    public class Product : IXmlSerializable
    {
        public string Code { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public Uri ImageUri { get; set; }
        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public virtual void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Code = reader.GetAttribute("Code");
            Model = reader.GetAttribute("Model");
            Name = reader.GetAttribute("Name");
            if (reader.ReadToDescendant("Image") && reader.HasAttributes)
                ImageUri = new Uri(reader.GetAttribute("Src"));
        }
        public virtual void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Code", Code);
            writer.WriteAttributeString("Model", Model);
            writer.WriteAttributeString("Name", Name);
            if (ImageUri != null)
            {
                writer.WriteStartElement("Image");
                writer.WriteAttributeString("Src", ImageUri.AbsoluteUri);
                writer.WriteEndElement();
            }
        }
    }
