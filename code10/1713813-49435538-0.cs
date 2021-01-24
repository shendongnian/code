    private Stream PrepareFile(string path)
    {
        string data = File.ReadAllText(path);
        var xml = XDocument.Parse(data);
        XNamespace ns = "http://schemas.datacontract.org/2004/07/HmsSim.EntityModule.Entities.SimulationEntities.Track";
        var longTracker = from item in xml.Descendants(ns + "LongitudinalTracker") select item;
        foreach (var xElement in longTracker.Elements())
        {
            XNamespace nsI = "http://www.w3.org/2001/XMLSchema-instance";
            if (xElement.Attribute(nsI + "type") != null)
            {
                xElement.Attribute(nsI + "type").Remove();
                XAttribute attribute = new XAttribute(nsI + "nil", "true");
                xElement.Add(attribute);
            }
        }
        var latTracker = from item in xml.Descendants(ns + "LateralTracker") select item;
        foreach (var xElement in latTracker.Elements())
        {
            XNamespace nsI = "http://www.w3.org/2001/XMLSchema-instance";
            if (xElement.Attribute(nsI + "type") != null)
            {
                xElement.Attribute(nsI + "type").Remove();
                XAttribute attribute = new XAttribute(nsI + "nil", "true");
                xElement.Add(attribute);
            }
        }
        Stream stream = new MemoryStream();
        xml.Save(stream);
        // Rewind the stream ready to read from it elsewhere
        stream.Position = 0;
        return stream;
    }
