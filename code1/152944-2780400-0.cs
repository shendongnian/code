    bool xmlvalid = true;
    string lastXmlError = "";
    doc.Validate(new System.Xml.Schema.ValidationEventHandler(
        delegate(object sender, System.Xml.Schema.ValidationEventArgs args)
        {
            if (args.Severity == System.Xml.Schema.XmlSeverityType.Error)
                {
                    xmlvalid = false;
                    lastXmlError = args.Message;
                }
        }));
    if (!xmlvalid)
       //raise error
