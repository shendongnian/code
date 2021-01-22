    // Add the Statements to the SAML Assertion
    samlAssert.Statements.Add(samlAuthStatement);
    samlAssert.Statements.Add(samlAttrStatement);
    using (var xmlStream = new MemoryStream())
    using (var xmlWriter = XmlDictionaryWriter.CreateTextWriter(xmlStream, System.Text.Encoding.UTF8))
    {
        var samlAssertSerializer = new SamlSerializer();
        var secTokenSerializer = new WSSecurityTokenSerializer();
        samlAssert.WriteXml(xmlWriter, samlAssertSerializer, secTokenSerializer);
        xmlWriter.Flush();
        xmlStream.Position = 0;
        using (var sr = new StreamReader(xmlStream, System.Text.Encoding.UTF8))
        {
            TextBox1.Text = sr.ReadToEnd();
        }
    }
