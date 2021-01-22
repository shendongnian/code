    XmlSchemaSet schemas = new XmlSchemaSet();
    schemas.Add(schemaNamespace, schemaFileName);
    XDocument doc = XDocument.Load(filename);
    string msg = "";
    doc.Validate(schemas, (o, e) => {
        msg = e.Message;
    });
    Console.WriteLine(msg == "" ? "Document is valid" : "Document invalid: " + msg);
