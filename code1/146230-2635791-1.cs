    var r = System.Xml.XmlReader.Create(new System.IO.StringReader("<Test> Result : this is the result</Test>"))
    while (r.Read()) {
       if (r.NodeType == XmlNodeType.Element && r.LocalName == "Test") {
         Console.Write(r.ReadElementContentAsString());
       }
    }
