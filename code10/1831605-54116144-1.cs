    [HttpPost]
    [Consumes("application/xml")]
    [Produces("application/xml")]
    public ActionResult<XmlDocument> EchoXmlAndChangeEncoding()
    {
        string requestXML = Request.Body;
        XmlDocument doc = new XmlDocument();
        doc.Load(new StringReader(requestXML));
        // Grab the XML declaration. 
        XmlDeclaration xmldecl = doc.ChildNodes.OfType<XmlDeclaration>().FirstOrDefault();
        xmldecl.Encoding = "UTF-8";
        xmldecl.Standalone = null;   // <-- or do whatever you need
        ... // set other declarations here
    
        // Output the modified XML document 
        return Ok(doc.OuterXml);
    }
