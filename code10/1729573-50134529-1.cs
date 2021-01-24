    public static class Signature
        {
            #region Private fields
            private const string SignatureId = "Signature";
            private const string SignaturePropertiesId = "SignedProperties";
            #endregion Private fields
    
            #region Public methods
            public static XmlElement SignWithXAdES(X509Certificate2 signingCertificate, XmlDocument xmlDocument)
            {
                var signedXml = new XadesSignedXml(xmlDocument);
                signedXml.Signature.Id = SignatureId;
                signedXml.SigningKey = signingCertificate.PrivateKey;
    
                var signatureReference = new Reference { Uri = "", };
                signatureReference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                signedXml.AddReference(signatureReference);
    
                var keyInfo = new KeyInfo();
                keyInfo.AddClause(new KeyInfoX509Data(signingCertificate));
                signedXml.KeyInfo = keyInfo;
    
                AddXAdESProperties(xmlDocument, signedXml, signingCertificate);
    
                signedXml.ComputeSignature();
    
                return signedXml.GetXml();
            }
            #endregion Public methods
    
            #region Private methods
            private static void AddXAdESProperties(XmlDocument document, XadesSignedXml xadesSignedXml, X509Certificate2 signingCertificate)
            {
                var parametersSignature = new Reference
                {
                    Uri = $"#{SignaturePropertiesId}",
                    Type = XadesSignedXml.XmlDsigSignatureProperties,
                };
                xadesSignedXml.AddReference(parametersSignature);
    
                // <Object>
                var objectNode = document.CreateElement("Object", SignedXml.XmlDsigNamespaceUrl);
    
                // <Object><QualifyingProperties>
                var qualifyingPropertiesNode = document.CreateElement(XadesSignedXml.XadesPrefix, "QualifyingProperties", XadesSignedXml.XadesNamespaceUrl);
                qualifyingPropertiesNode.SetAttribute("Target", $"#{SignatureId}");
                objectNode.AppendChild(qualifyingPropertiesNode);
    
                // <Object><QualifyingProperties><SignedProperties>
                var signedPropertiesNode = document.CreateElement(XadesSignedXml.XadesPrefix, "SignedProperties", XadesSignedXml.XadesNamespaceUrl);
                signedPropertiesNode.SetAttribute("Id", SignaturePropertiesId);
                qualifyingPropertiesNode.AppendChild(signedPropertiesNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties>
                var signedSignaturePropertiesNode = document.CreateElement(XadesSignedXml.XadesPrefix, "SignedSignatureProperties", XadesSignedXml.XadesNamespaceUrl);
                signedPropertiesNode.AppendChild(signedSignaturePropertiesNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties> </SigningTime>
                var signingTime = document.CreateElement(XadesSignedXml.XadesPrefix, "SigningTime", XadesSignedXml.XadesNamespaceUrl);
                signingTime.InnerText = $"{DateTime.UtcNow.ToString("s")}Z";
                signedSignaturePropertiesNode.AppendChild(signingTime);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate>
                var signingCertificateNode = document.CreateElement(XadesSignedXml.XadesPrefix, "SigningCertificate", XadesSignedXml.XadesNamespaceUrl);
                signedSignaturePropertiesNode.AppendChild(signingCertificateNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert>
                var certNode = document.CreateElement(XadesSignedXml.XadesPrefix, "Cert", XadesSignedXml.XadesNamespaceUrl);
                signingCertificateNode.AppendChild(certNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><CertDigest>
                var certDigestNode = document.CreateElement(XadesSignedXml.XadesPrefix, "CertDigest", XadesSignedXml.XadesNamespaceUrl);
                certNode.AppendChild(certDigestNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><CertDigest> </DigestMethod>
                var digestMethod = document.CreateElement("DigestMethod", SignedXml.XmlDsigNamespaceUrl);
                var digestMethodAlgorithmAtribute = document.CreateAttribute("Algorithm");
                digestMethodAlgorithmAtribute.InnerText = SignedXml.XmlDsigSHA1Url;
                digestMethod.Attributes.Append(digestMethodAlgorithmAtribute);
                certDigestNode.AppendChild(digestMethod);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><CertDigest> </DigestMethod>
                var digestValue = document.CreateElement("DigestValue", SignedXml.XmlDsigNamespaceUrl);
                digestValue.InnerText = Convert.ToBase64String(signingCertificate.GetCertHash());
                certDigestNode.AppendChild(digestValue);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><IssuerSerial>
                var issuerSerialNode = document.CreateElement(XadesSignedXml.XadesPrefix, "IssuerSerial", XadesSignedXml.XadesNamespaceUrl);
                certNode.AppendChild(issuerSerialNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><IssuerSerial> </X509IssuerName>
                var x509IssuerName = document.CreateElement("X509IssuerName", SignedXml.XmlDsigNamespaceUrl);
                x509IssuerName.InnerText = signingCertificate.Issuer;
                issuerSerialNode.AppendChild(x509IssuerName);
    
                // <Object><QualifyingProperties><SignedProperties><SignedSignatureProperties><SigningCertificate><Cert><IssuerSerial> </X509SerialNumber>
                var x509SerialNumber = document.CreateElement("X509SerialNumber", SignedXml.XmlDsigNamespaceUrl);
                x509SerialNumber.InnerText = ToDecimalString(signingCertificate.SerialNumber);
                issuerSerialNode.AppendChild(x509SerialNumber);
    
                // <Object><QualifyingProperties><SignedProperties><SignedDataObjectProperties>
                var signedDataObjectPropertiesNode = document.CreateElement(XadesSignedXml.XadesPrefix, "SignedDataObjectProperties", XadesSignedXml.XadesNamespaceUrl);
                signedPropertiesNode.AppendChild(signedDataObjectPropertiesNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedDataObjectProperties><CommitmentTypeIndication>
                var commitmentTypeIndicationNode = document.CreateElement(XadesSignedXml.XadesPrefix, "CommitmentTypeIndication", XadesSignedXml.XadesNamespaceUrl);
                signedDataObjectPropertiesNode.AppendChild(commitmentTypeIndicationNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedDataObjectProperties><CommitmentTypeIndication><CommitmentTypeId>
                var commitmentTypeIdNode = document.CreateElement(XadesSignedXml.XadesPrefix, "CommitmentTypeId", XadesSignedXml.XadesNamespaceUrl);
                commitmentTypeIndicationNode.AppendChild(commitmentTypeIdNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedDataObjectProperties><CommitmentTypeIndication><CommitmentTypeId><Identifier>
                var identifierNode = document.CreateElement(XadesSignedXml.XadesPrefix, "Identifier", XadesSignedXml.XadesNamespaceUrl);
                identifierNode.InnerText = XadesSignedXml.XadesProofOfApproval;
                commitmentTypeIdNode.AppendChild(identifierNode);
    
                // <Object><QualifyingProperties><SignedProperties><SignedDataObjectProperties><CommitmentTypeIndication><AllSignedDataObjects>
                var allSignedDataObjectsNode = document.CreateElement(XadesSignedXml.XadesPrefix, "AllSignedDataObjects", XadesSignedXml.XadesNamespaceUrl);
                commitmentTypeIndicationNode.AppendChild(allSignedDataObjectsNode);
    
                var dataObject = new DataObject();
                dataObject.Data = qualifyingPropertiesNode.SelectNodes(".");
                xadesSignedXml.AddObject(dataObject);
            }
    
            private static string ToDecimalString(string serialNumber)
            {
                BigInteger bi;
    
                if (BigInteger.TryParse(serialNumber, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out bi))
                {
                    return bi.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    return serialNumber;
                }
            }
            #endregion Private methods
        }
