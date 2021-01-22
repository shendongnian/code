    public class Service : IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema  GetSchema()
        {
    	    return null;
        }
    
        public void  ReadXml(System.Xml.XmlReader reader)
        {
    	    List<string> element3 = new List<string>();
    
    	    while (reader.Read())
    	    {
    		if (reader.Name == "Element1" && reader.NodeType == XmlNodeType.Element)
    		{
    			Element1 = Convert.ToBoolean(reader.ReadString());
    		}
    		else if (reader.Name == "Element2" && reader.NodeType == XmlNodeType.Element)
    		{
    			Element2 = reader.ReadString();
    		}
    		if (reader.Name == "Element1" && reader.NodeType == XmlNodeType.Element)
    		{
    			element3.Add(reader.ReadString());
    		}
    	    }
    
    	    Element3 = element3.ToArray();
        }
    
        public void  WriteXml(System.Xml.XmlWriter writer)
        {
    	    writer.WriteStartElement ("Service"); 
    	    writer.WriteStartElement ("Element1"); 
    		writer.WriteString(Element1.ToString());
    	    writer.WriteEndElement();
    	    writer.WriteStartElement ("Element2"); 
    		writer.WriteString(Element2.ToString());
    	    writer.WriteEndElement();
    
    	    foreach (string ele in Element3)
    	    {
    		writer.WriteStartElement ("Element3"); 
    		writer.WriteString(ele);
    		writer.WriteEndElement();
    	    }
    	    writer.WriteEndElement();
        }
    }
