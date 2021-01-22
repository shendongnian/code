    // Add the Statements to the SAML Assertion
    samlAssert.Statements.Add(samlAuthStatement);
    samlAssert.Statements.Add(samlAttrStatement);
    
    var sb = new StringBuilder();
    var settings = new XmlWriterSettings 
    {
        OmitXmlDeclaration = true,
        Encoding = Encoding.UTF8
    };
    using (var stringWriter = new StringWriter(sb))
    using (var xmlWriter = XmlWriter.Create(stringWriter, settings))
    using (var dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
    {
        var samlAssertSerializer = new SamlSerializer();
        var secTokenSerializer = new WSSecurityTokenSerializer();
        samlAssert.WriteXml(
            dictionaryWriter, 
            samlAssertSerializer, 
            secTokenSerializer
        );
    }
    
    TextBox1.Text = sb.ToString();
