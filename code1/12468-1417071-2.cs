    private static string beautify(string xml)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xml);
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t",
            NewLineChars = Environment.NewLine,
            NewLineHandling = NewLineHandling.Replace,
            Encoding = new UTF8Encoding(false)
        };
        using (var ms = new MemoryStream())
        using (var writer = XmlWriter.Create(ms, settings))
        {
            doc.Save(writer);
            var xmlString = Encoding.UTF8.GetString(ms.ToArray());
            return xmlString;
        }
    }
