    XmlSchema schema;
    using (MemoryStream stream =	new MemoryStream())
    using (FileStream fs = new FileStream("MySchema.xsd", FileMode.Open))
    using(XmlReader reader = XmlReader.Create(fs)) {
      XslCompiledTransform transform = new XslCompiledTransform();
      transform.Load("SchemaTransform.xslt");
      transform.Transform(reader, null, stream);
      stream.Seek(0, SeekOrigin.Begin);
      schema = XmlSchema.Read(stream, null);
    }
    XmlDocument doc = new XmlDocument();
    doc.Schemas.Add(schema);
    doc.Load("rootelement.xml");
    XmlNodeList nodes = doc.GetElementsByTagName("NestedElement");
    doc.Validate(ValidationHandler);
