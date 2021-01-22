    // input-xml
    string xmlinput = String.Empty;
    // xslt
    string xsltinput = String.Empty;
    // output-xml
    string xmloutput = String.Empty;
    
    // Prepare input-xml
    XPathDocument doc = new XPathDocument(new StringReader(xmlinput));
                
    // Prepare XSLT
    XslTransform xslt = new XslTransform();
    // Creates a XmlReader from your xsl string
    using (XmlReader xmlreader = XmlReader.Create(new StringReader(xsltinput)))
    {
        //Load the stylesheet.
        xslt.Load(xmlreader);
    
        // transform
        using (StringWriter sw = new StringWriter())
        {
            xslt.Transform(doc, null, sw);
    
            // save to string
            xmloutput = sw.ToString();
        }
    }
