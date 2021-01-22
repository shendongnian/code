        public class ItemCollection : Collection<Item>,IXmlSerializable
        {
            private string _name;
    
            public ItemCollection()
            {
                _name = string.Empty;
            }
    
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
     #region IXmlSerializable Members
        
             public System.Xml.Schema.XmlSchema GetSchema()
             {
                  return null;
             }
        
             public void ReadXml(System.Xml.XmlReader reader)
             {
                   
             }
        
             public void WriteXml(System.Xml.XmlWriter writer)
             {
                  writer.WriteElementString("name", _name);
                  List<Item> coll = new List<Item>(this.Items);
                  XmlSerializer serializer = new XmlSerializer(coll.GetType());
                  serializer.Serialize(writer, coll);
                    
             }
        
    #endregion
       }
