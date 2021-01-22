    var writer = new XmlTextWriter("Foo.xml", Encoding.UTF8);
    writer.WriteStartDocument();
    writer.WriteStartElement("Foo");
    writer.WriteAttributeString("hello", "world"); 
    writer.WriteEndElement();
    writer.WriteEndDocument();
    writer.Close();
