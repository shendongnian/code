    var sb = new StringBuilder();
    var settings = new XmlWriterSettings {Indent = true};
    using (var writer = XmlWriter.Create(sb, settings))
    {
        // write your XML using the writer
    }
    // Indented results available in sb.ToString()
