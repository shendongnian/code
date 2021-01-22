    // Load document
    XDocument doc = XDocument.Load("file.xml");
    // Extract value of xsi:noNamespaceSchemaLocation
    XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
    string schemaURI = (string)doc.Root.Attribute(xsi + "noNamespaceSchemaLocation");
    // Create schema set
    XmlSchemaSet schemas = new XmlSchemaSet();
    schemas.Add("Schemas", schemaURI);
    // Validate
    doc.Validate(schemas, (o, e) =>
                          {
                              Console.WriteLine("{0}", e.Message);
                          });
