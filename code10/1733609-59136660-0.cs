      var signedXml = new SignedXml(doc);
      var isValid = doc.GetElementsByTagName("Signature", "http://www.w3.org/2000/09/xmldsig#")
                          .OfType<XmlElement>()
                          .ToArray()
                          .All(e =>
                          {
                              //workaround - remove the signature element here.
                              e.ParentNode.RemoveChild(e);
                              signedXml.LoadXml(e);
                              return signedXml.CheckSignature(cert, true);
                          });
 
