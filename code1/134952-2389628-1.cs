    string output = String.Empty;
    using (StringReader srt = new StringReader(xslInput)) // xslInput is a string that contains xsl
    using (StringReader sri = new StringReader(xmlInput)) // xmlInput is a string that contains xml
    {
        using (XmlReader xrt = XmlReader.Create(srt))
        using (XmlReader xri = XmlReader.Create(sri))
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xrt);
            using (StringWriter sw = new StringWriter())
            using (XmlWriter xwo = XmlWriter.Create(sw, xslt.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
            {
                xslt.Transform(xri, xwo);
                output = sw.ToString();
            }
        }
    }
