    XmlSchemaInference inf = new XmlSchemaInference();
                  
    // xml variable on the next line is a string being passed in
    XmlSchemaSet schemas = inf.InferSchema(new XmlTextReader(xml, XmlNodeType.Element, null));
    schemas.Compile();
    
    XmlSchema[] schemaArray = new XmlSchema[1];
    schemas.CopyTo(schemaArray, 0);
    XmlTextWriter wr = new XmlTextWriter(xsdOutputFileNameAndPath, Encoding.UTF8);
    wr.Formatting = Formatting.Indented;
    schemaArray[0].Write(wr);
    wr.Close();
