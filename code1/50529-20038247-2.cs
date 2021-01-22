    public static string StripTags(this string markup)
    {
        try
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
            return doc.CreateNavigator().Value; // .Value is similar to .InnerText of  
                                               //  XmlDocument or JavaScript's innerText
        }
        catch
        {
            return string.Empty;
        }
    }
