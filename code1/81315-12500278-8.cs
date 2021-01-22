    // arbitrary limit of 10MB
    long FileSizeLimit = 10*1024*1024;
    // open file stream to monitor file size
    using (FileStream file = new FileStream("some.data.xml", FileMode.Create))
    using (XmlWriter writer = XmlWriter.Create(file))
    {
        writer.WriteStartElement("root");
        // while not greater than FileSizeLimit
        for (; file.Length < FileSizeLimit; )
        {
            // write contents
            writer.WriteElementString(
                "data", 
                string.Format("{0}/{0}/{0}/{0}/{0}", Guid.NewGuid()));
        }
        // complete fragment; this is the trickiest part, 
        // since a complex document may have an arbitrarily
        // long tail, and cannot be known during file size
        // sampling above
        writer.WriteEndElement();
        writer.Flush();
    }
    // iteratively reduce document size
    // NOTE: XDocument will load full DOM into memory
    XDocument document = XDocument.Load("some.data.xml");
    XElement root = document.Element("root");
    for (; new FileInfo("some.data.xml").Length > FileSizeLimit; )
    {
        root.LastNode.Remove();
        document.Save("some.data.xml");
    }
