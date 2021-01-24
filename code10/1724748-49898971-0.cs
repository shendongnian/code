    public static IEnumerable<XNode> Parse(string text)
    {
        var settings = new XmlReaderSettings
        {
            ConformanceLevel = ConformanceLevel.Fragment
        };
        using (var sr = new StringReader(text))
        using (var xr = XmlReader.Create(sr, settings))
        {
            xr.MoveToContent();
            while (xr.EOF == false)
            {
                yield return XNode.ReadFrom(xr);
            }
        }
    }
