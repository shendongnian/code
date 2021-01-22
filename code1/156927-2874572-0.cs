    public void SetDefaultXmlNamespace(XElement xelem, XNamespace xmlns)
    {
        if(xelem.Name.NamespaceName == string.Empty)
            xelem.Name = xmlns + xelem.Name.LocalName;
        foreach(var e in xelem.Elements())
            SetDefaultXmlNamespace(e, xmlns);
    }
    // ...
    SetDefaultXmlNamespace(doc.Root, "http://schemas.datacontract.org/2004/07/Widgets");
