        [XmlRoot(ElementName="People")]
    public class PersonCollection : List<Person>, IXmlSerializable
    {
        //IT WORKS NOW!!! Too bad we have to implement IXmlSerializable
        [XmlAttribute]
        public string FavoritePerson { get; set; }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            FavoritePerson = reader[0];            
            while (reader.Read())
            {
                if (reader.Name == "Person")
                {
                    var p = new Person();
                    p.FirstName = reader[0];
                    p.Age = int.Parse( reader[1] ); 
                    Add(p);
                }
            }
        }
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("FavoritePerson", FavoritePerson);
            foreach (var p in this)
            {
                writer.WriteStartElement("Person");
                writer.WriteAttributeString("FirstName", p.FirstName);
                writer.WriteAttributeString("Age", p.Age.ToString());
                writer.WriteEndElement();            
            }
        }
    }
