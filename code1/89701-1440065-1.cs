    public static XDocument XDocumentFromString(string baseUri, string xml)
    {
        var xdoc = XDocument.Parse(xml);
        xdoc.AddAnnotation(new MyBaseUriAnnotation(xdoc, baseUri));
    }
