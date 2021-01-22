    public static string StripTags(this string markup) 
    {
        StringReader sr = new StringReader(markup);
        XPathDocument doc;
        using (XmlReader xr = XmlReader.Create(sr,
                           new XmlReaderSettings()
                           {
                               ConformanceLevel = ConformanceLevel.Fragment
                               // for multiple roots
                           }))
        {
            doc = new XPathDocument(xr);
        }
        return doc.CreateNavigator().Value; // .Value is same as InnerText of XmlDocument 
                                            //  or JavaScript's innerText
    }
