    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(@"<foo><bar abc=""def"">ghi</bar></foo>");
        var el = doc.SelectSingleNode("/foo/bar");
        var s = ReadXml(el);
        Console.WriteLine(s);
    }
    private static string ReadXml(XmlNode element)
    {
        using (var reader = new XmlNodeReader(element))
        {
            reader.MoveToContent();
            return reader.ReadOuterXml();
        }
    }
