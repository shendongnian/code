       public class Animal : IXmlSerializable
    {
       
        public Animal()
        {
        }
        bool _isBipedal;
        public bool IsBipedal
        {
            get { return _isBipedal; }
            set { _isBipedal = value; }
        }
        string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
   
            Name = reader.GetAttribute("Name");
            reader.ReadStartElement(); 
            IsBipedal = bool.Parse(reader.ReadElementString("IsBipedal") == "Yes" ? "true" : "false");
            reader.ReadEndElement(); 
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Name", Name);
            writer.WriteElementString("IsBipedal", IsBipedal ? "Yes" : "No");
        }
    }
