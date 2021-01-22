    System.Xml.XmlTextReader textReader = new System.Xml.XmlTextReader("testin.xml");
    textReader.EntityHandling = System.Xml.EntityHandling.ExpandEntities;
    System.Xml.XmlDocument outputDoc = new System.Xml.XmlDocument();
    outputDoc.Load(textReader);
    System.Xml.XmlDocumentType docTypeIfPresent = outputDoc.DocumentType;
    if (docTypeIfPresent != null)
        outputDoc.RemoveChild(docTypeIfPresent);
    outputDoc.Save("testout.html");
    textReader.Close();
