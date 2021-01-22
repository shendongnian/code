    public static string FormatXmlString(string unformattedXml)
    {
        XmlDocument document = new XmlDocument();
        document.LoadXml(unformattedXml);
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        using (XmlWriter writer = XmlWriter.Create(sb, settings))
        {
            document.WriteTo(writer);
        }
        return sb.ToString();
    }
