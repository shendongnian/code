    public static Stream BuildRDLCStream(
        DataSet data, string name, string reportXslPath)
    {
      using (MemoryStream schemaStream = new MemoryStream())
      {
        // save the schema to a stream
        data.WriteXmlSchema(schemaStream);
        schemaStream.Seek(0, SeekOrigin.Begin);
        // load it into a Document and set the Name variable
        XmlDocument xmlDomSchema = new XmlDocument();
        xmlDomSchema.Load(schemaStream);        
        xmlDomSchema.DocumentElement.SetAttribute("Name", data.DataSetName);
        // load the report's XSL file (that's the magic)
        XslCompiledTransform xform = new XslCompiledTransform();
        xform.Load(reportXslPath);
        // do the transform
        MemoryStream rdlcStream = new MemoryStream();
        XmlWriter writer = XmlWriter.Create(rdlcStream);
        xform.Transform(xmlDomSchema, writer);
        writer.Close();
        rdlcStream.Seek(0, SeekOrigin.Begin);
        // send back the RDLC
        return rdlcStream;
      }
    }
