    XmlDocument contractHistoryXMLSchemaDoc = new XmlDocument();
    
    using (MemoryStream ms = new MemoryStream())
    {
       dsContract.WriteXml(ms);
       ms.Seek(0, SeekOrigin.Begin);
       using(XmlReader xmlR = XmlReader.Create(ms))
       {
           contractHistoryXMLSchemaDoc.Load(xmlR);
       }
    
    }
