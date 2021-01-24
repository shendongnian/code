    using System;
    using System.Xml;
    using System.Security.Cryptography.X509Certificates;
    using System.Security.Cryptography.Xml;
    
    private void SignXmlNodes(
       string filename,
       string mainChildTag,
       string idAttributeTag,
       X509Certificate2 x509Cert)
    {
       XmlDocument xmlDoc = new XmlDocument();
       // Format the document to ignore white spaces.
       xmlDoc.PreserveWhitespace = false;
       xmlDoc.Load(filename);
    
       XmlNodeList mainChildList = xmlDoc.GetElementsByTagName(mainChildTag);
       // Loop through the nodes that need to be signed.
       foreach (XmlNode mainChildNode in mainChildList)
       {
          XmlNode nodeForSigning = mainChildNode.ParentNode;
    
          // It's necessary to create a namespace manager to use with SelectNode methods,
          // otherwise they won't work, because the node has a specific namespace.
          var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
          nsmgr.AddNamespace("ns", nodeForSigning.NamespaceURI);
          nsmgr.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
    
          XmlNode nodeWithTheId = nodeForSigning.SelectSingleNode($"ns:{idAttributeTag}", nsmgr);
          if (nodeWithTheId == null)
          {
             throw new Exception($"The tag with ID attribute '{idAttributeTag}' does not exist in the XML file. (Error code: 4)");
          }
          // Uses null-conditional (?.) and null-coalescing (??) operators to set the reference Uri.
          string refUri = nodeWithTheId.Attributes?["id"]?.Value ?? "";
          if (!string.IsNullOrEmpty(refUri))
          {
             refUri = $"#{refUri}";
          }
    
          // Remove existing signatures in the node, if there's any.
          foreach (XmlNode node in nodeForSigning.SelectNodes("ds:Signature", nsmgr))
          {
             node.ParentNode.RemoveChild(node);
          }
    
          SignedXml signedXml = new SignedXml((XmlElement) nodeForSigning);
          // Add the key to the SignedXml document
          signedXml.SigningKey = x509Cert.PrivateKey;
          signedXml.SignedInfo.SignatureMethod = SignedXml.XmlDsigRSASHA1Url;
    
          // Create a reference with the specified Uri (id of the informed tag).
          Reference reference = new Reference(refUri);
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
          //xmlDoc.DocumentElement.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
          nodeForSigning.AppendChild(xmlDoc.ImportNode(xmlDigitalSignature, true));
       }
    
       xmlDoc.Save(filename);
    }
