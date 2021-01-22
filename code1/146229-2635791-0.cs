    var r = System.Xml.XmlReader.Create(new System.IO.StringReader(<xmlstring>))
    while (r.Read()) {
       if (r.NodeType == XmlNodeType.Element && r.LocalName == "Test") {
         Console.Write(r.ReadElementContentAsString());
       }
    }
