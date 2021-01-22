    XmlDocument contractHistoryXMLSchemaDoc = new XmlDocument();
    using (MemoryStream ms = new MemoryStream())
    {
        dsContract.WriteXmlSchema(ms);
        ms.Seek(0, SeekOrigin.Begin);
        contractHistoryXMLSchemaDoc.Load(ms);
    }
