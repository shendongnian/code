        XmlTextWriter xWriter = new XmlTextWriter(Console.Out);    
        xWriter.WriteStartElement("prefix", "Element1", "namespace"); 
        xWriter.WriteStartAttribute("prefix", "Attr1", "namespace1"); 
        xWriter.WriteString("value1"); 
        xWriter.WriteStartAttribute("prefix", "Attr2", "namespace2"); 
        xWriter.WriteString("value2"); 
        xWriter.Close();
 
