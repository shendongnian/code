    var myXmlString = "<xml>...</xml>"; // Your original XML string that needs indenting.
    var myNewXmlString = "";
    var doc = new XmlDocument();
    var sb = new StringBuilder();
    var settings = new XmlWriterSettings();
    doc.LoadXml(myXmlString);
    settings.Indent = true;
    settings.IndentChars = "  ";
    settings.NewLineChars = "\r\n";
    settings.NewLineHandling = NewLineHandling.Replace;
    using (XmlWriter writer = XmlWriter.Create(sb, settings))
    {
        doc.Save(writer);
    }
    myNewXmlString = sb.ToString();
