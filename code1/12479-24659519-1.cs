    var xmlString = "<xml>...</xml>"; // Your original XML string that needs indenting.
    xmlString = this.PrettifyXml(xmlString);
    private string PrettifyXml(string xmlString)
    {
        var prettyXmlString = new StringBuilder();
        var xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlString);
        var xmlSettings = new XmlWriterSettings()
        {
            Indent = true,
            IndentChars = " ",
            NewLineChars = "\r\n",
            NewLineHandling = NewLineHandling.Replace
        };
        using (XmlWriter writer = XmlWriter.Create(prettyXmlString, xmlSettings))
        {
            xmlDoc.Save(writer);
        }
        return prettyXmlString.ToString();
    }
