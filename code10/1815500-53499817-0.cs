    using System;
    using System.Xml;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    
    private void SignXmlFile(
       string filename,
       string idAttributeTag,
       X509Certificate2 x509Cert)
    {
       XmlDocument xmldoc = new XmlDocument();
       // Format the document to ignore white spaces.
       xmldoc.PreserveWhitespace = false;
       xmldoc.Load(filename);
    
       XmlNodeList list = xmldoc.GetElementsByTagName(idAttributeTag);
       if (list.Count == 0)
       {
          throw new Exception($"The tag with ID attribute '{idAttributeTag}' does not exist in the XML file. (Error code: 4)");
       }
    
       SignedXml signedXml = new SignedXml(xmldoc);
       // Add the key to the SignedXml document
       signedXml.SigningKey = x509Cert.PrivateKey;
       signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
    
       // Create a reference with the specified Uri (id of the informed tag).
       Reference reference = new Reference($"#{list[0].Attributes["id"].Value}");
       reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
       reference.AddTransform(new XmlDsigC14NTransform());
       reference.DigestMethod = SignedXml.XmlDsigSHA1Url;
       // Add the reference to the SignedXml object.
       signedXml.AddReference(reference);
    
       signedXml.KeyInfo = new KeyInfo();
       // Load the certificate into a KeyInfoX509Data object
       // and add it to the KeyInfo object.
       signedXml.KeyInfo.AddClause(new KeyInfoX509Data(x509Cert));
    
       // Compute the signature.
       signedXml.ComputeSignature();
    
       // Get the XML representation of the signature and save
       // it to an XmlElement object.
       XmlElement xmlDigitalSignature = signedXml.GetXml();
    
       // Append the signature element to the XML document.
       xmldoc.DocumentElement.AppendChild(xmldoc.ImportNode(xmlDigitalSignature, true));
    }
