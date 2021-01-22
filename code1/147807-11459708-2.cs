    XmlDocument contractHistoryXMLDoc = new XmlDocument();
    using (MemoryStream ms = new MemoryStream())
    {
        dsContract.WriteXml(ms,XmlWriteMode.WriteSchema);
        ms.Seek(0, SeekOrigin.Begin);
        contractHistoryXMLDoc.Load(ms);
    }
