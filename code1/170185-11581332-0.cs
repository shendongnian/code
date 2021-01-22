    static void WritePreProcessor(Parameters p)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(p.InputXml);
        XmlProcessingInstruction pi = doc.CreateProcessingInstruction(p.Name, p.Value);
        XmlNode root = doc.DocumentElement;
        doc.InsertBefore(pi, root);
        doc.Save(p.OutputXml);
    }
