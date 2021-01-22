    XmlTextWriter textWriter = new XmlTextWriter("po.xml", null);
    textWriter.Formatting    = Formatting.Indented;
    XmlQualifiedName qname   = new XmlQualifiedName("PurchaseOrder",       
                               "http://tempuri.org");
    XmlSampleGenerator generator = new XmlSampleGenerator("po.xsd", qname);
    genr.WriteXml(textWriter);
