    System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(Server.MapPath("pages.xml"), System.Text.Encoding.UTF8);
    
    		writer.WriteStartDocument();
    		writer.WriteStartElement("pages");
    
            writer.WriteStartElement("page");
    		writer.WriteAttributeString("name", "Page name 1");
    		writer.WriteAttributeString("url", "Page url 1");
    		writer.WriteEndElement();
            writer.WriteStartElement("page");
    		writer.WriteAttributeString("name", "Page name 2 ");
    		writer.WriteAttributeString("url", "Page url 2");
    		writer.WriteEndElement();
            writer.WriteStartElement("page");
    		writer.WriteAttributeString("name", "Page name 3");
    		writer.WriteAttributeString("url", "Page url 3");
    		writer.WriteEndElement();
   
    		writer.WriteEndElement();
    		writer.WriteEndDocument();
    		writer.Close();  
