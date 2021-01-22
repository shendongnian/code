    static public string Beautify(XmlDocument doc)
    {
        StringBuilder sb = new StringBuilder();
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
        settings.IndentChars = "  ";
        settings.NewLineChars = "\r\n";
        settings.NewLineHandling = NewLineHandling.Replace;
        XmlWriter writer = XmlWriter.Create(sb, settings);
        doc.Save(writer);
        writer.Close();
        return sb.ToString();
    }
