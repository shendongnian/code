    public static void WrapTransform(
        Stream outputStream, 
        string styleSheetUri, 
        string documentUri)
    {
        var transform = new XslCompiledTransform();
        using (var styleSheetReader = XmlReader.Create(styleSheetUri))
        {
            transform.Load(styleSheetReader);
        }
        using (var wrapper = XmlWriter.Create(outputStream))
        {
            wrapper.WriteStartElement("Root");
            transform.Transform(documentUri, wrapper);
            wrapper.WriteEndElement();
        }
    }
