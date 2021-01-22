    IEnumerable<LicenceObjects> licenses = //some code to make them;
    
    XDocument doc = new XDocument(
        new XDeclaration("1.0", "utf-8", "yes"),
        new XElement("Equipment",
            licenses.Select(l => 
                new XElement("License", 
                    new XAttribute("licenseId", l.licenseId), 
                    new XAttribute("licensePath", l.licensePath)
                )
            )
        )
    );
    
    string xmlDocumentString = doc.ToString();
