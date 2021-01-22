    // Assume we have a type named 'MyType' and a variable of this type named 
    'myObject' 
    System.Text.StringBuilder output = new System.Text.StringBuilder(); 
    System.IO.StringWriter internalWriter = new System.IO.StringWriter(output); 
    System.Xml.XmlWriter writer = new System.Xml.XmlTextWriter(internalWriter); 
    System.Xml.Serialization.XmlSerializer serializer = new 
    System.Xml.Serialization.XmlSerializer(typeof(MyType)); 
    writer.WriteStartElement("MyContainingElement"); 
    serializer.Serialize(writer, myObject); 
    writer.WriteEndElement(); 
