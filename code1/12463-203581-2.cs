    static public string Beautify(this XmlDocument doc)
    {
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineChars = "\r\n";
        settings.NewLineHandling = NewLineHandling.Replace;
        using (XmlWriter writer = XmlWriter.Create(sb, settings)) {
            doc.Save(writer);
        }
        return sb.ToString();
    }
