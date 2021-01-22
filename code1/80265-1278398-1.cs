    using (XmlWriter writer = XmlWriter.Create(builder))
    {
    	writer.WriteStartDocument();
    	{
    		writer.WriteStartElement("root");
    		{
    			writer.WriteStartElement("Node1");
    			writer.WriteAttributeString("att1", "value");
    			writer.WriteEndElement();
    
    			writer.WriteStartElement("Node2");
    			writer.WriteString("inner text");
    			writer.WriteEndElement();
    		}
    		writer.WriteEndElement();
    	}
    	writer.WriteEndDocument();
    }
