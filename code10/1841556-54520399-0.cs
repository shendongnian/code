    var xRoot = new XmlRootAttribute
    {
        ElementName = nameof(Response),
        Namespace = "http://www.sap.com/SBO/DIS",
        IsNullable = true
    };
    var xor = new XmlAttributeOverrides();
    xor.Add(typeof(Response), nameof(Response.RetKey), new XmlAttributes
    {
        XmlElements = { new XmlElementAttribute(nameof(Response.RetKey))
            { Namespace = xRoot.Namespace } }
    });
    xor.Add(typeof(Response), nameof(Response.RetType), new XmlAttributes
    {
        XmlElements = { new XmlElementAttribute(nameof(Response.RetType))
            { Namespace = xRoot.Namespace } }
    });
    var xmlSerializer = new XmlSerializer(typeof(Response),
        xor, Type.EmptyTypes, xRoot, xRoot.Namespace);
