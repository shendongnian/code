    private static FlowDocument SetRTF(string xamlString)
    {
        StringReader stringReader = new StringReader(xamlString);
        System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
        Section sec = XamlReader.Load(xmlReader) as Section;
        FlowDocument doc = new FlowDocument();
        while (sec.Blocks.Count > 0)
        {
            var block = sec.Blocks.FirstBlock;
            sec.Blocks.Remove(block);
            doc.Blocks.Add(block);
        }
        return doc;
    }
