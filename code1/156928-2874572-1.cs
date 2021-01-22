    public static void SetDefaultXmlNamespace(this XElement xelem, XNamespace xmlns)
    {
        if(xelem.Name.NamespaceName == string.Empty)
            xelem.Name = xmlns + xelem.Name.LocalName;
        foreach(var e in xelem.Elements())
            e.SetDefaultXmlNamespace(xmlns);
    }
    // ...
    doc.Root.SetDefaultXmlNamespace("http://schemas.datacontract.org/2004/07/Widgets");
