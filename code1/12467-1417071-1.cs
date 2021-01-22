    private static string beautify(
        XmlDocument doc)
    {
        var sb = new StringBuilder();
        var settings =
            new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = @"    ",
                    NewLineChars = Environment.NewLine,
                    NewLineHandling = NewLineHandling.Replace,
                };
        
        using (var writer = XmlWriter.Create(sb, settings))
        {
            if (doc.ChildNodes[0] is XmlProcessingInstruction)
            {
                doc.RemoveChild(doc.ChildNodes[0]);
            }
        
            doc.Save(writer);
            return sb.ToString();
        }
    }
