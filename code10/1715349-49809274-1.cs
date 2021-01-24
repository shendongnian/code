    public class Certificate
    {
        public X509Certificate2 cert;
        public void LoadCertificate()
        {
            string certificate = "-----BEGIN CERTIFICATE-----certificate data -----END CERTIFICATE-----";
            cert = new X509Certificate2(certificate);
            cert.Import(StringToByteArray(certificate));
        }
        public void LoadCertificate(byte[] certificate)
        {
            cert = new X509Certificate2();
            cert.Import(certificate);
        }
        private byte[] StringToByteArray(string st)
        {
            byte[] bytes = new byte[st.Length];
            for (int i = 0; i < st.Length; i++)
            {
                bytes[i] = (byte)st[i];
            }
            return bytes;
        }
    }
    public class Response
    {
        private XmlDocument xmlDoc;
        private Certificate certificate;
        public Response()
        {
            certificate = new Certificate();
            certificate.LoadCertificate();
        }
        public void LoadXml(string xml)
        {
            xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.XmlResolver = null;
            xmlDoc.LoadXml(xml);
        }
        public void LoadXmlFromBase64(string response)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            LoadXml(enc.GetString(Convert.FromBase64String(response)));
        }
        public bool IsValid()
        {
            bool status = true;
            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            XmlNodeList nodeList = xmlDoc.SelectNodes("//ds:Signature", manager);
            SignedXml signedXml = new SignedXml(xmlDoc);
            signedXml.LoadXml((XmlElement)nodeList[0]);
            status &= signedXml.CheckSignature(certificate.cert, true);
            var notBefore = NotBefore();
            status &= !notBefore.HasValue || (notBefore <= DateTime.Now);
            var notOnOrAfter = NotOnOrAfter();
            status &= !notOnOrAfter.HasValue || (notOnOrAfter > DateTime.Now);
            return status;
        }
        public DateTime? NotBefore()
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            var nodes = xmlDoc.SelectNodes("/samlp:Response/saml:Assertion/saml:Conditions", manager);
            string value = null;
            if (nodes != null && nodes.Count > 0 && nodes[0] != null && nodes[0].Attributes != null && nodes[0].Attributes["NotBefore"] != null)
            {
                value = nodes[0].Attributes["NotBefore"].Value;
            }
            return value != null ? DateTime.Parse(value) : (DateTime?)null;
        }
        public DateTime? NotOnOrAfter()
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            var nodes = xmlDoc.SelectNodes("/samlp:Response/saml:Assertion/saml:Conditions", manager);
            string value = null;
            if (nodes != null && nodes.Count > 0 && nodes[0] != null && nodes[0].Attributes != null && nodes[0].Attributes["NotOnOrAfter"] != null)
            {
                value = nodes[0].Attributes["NotOnOrAfter"].Value;
            }
            return value != null ? DateTime.Parse(value) : (DateTime?)null;
        }
        public string GetNameID()
        {
            XmlNamespaceManager manager = new XmlNamespaceManager(xmlDoc.NameTable);
            manager.AddNamespace("ds", SignedXml.XmlDsigNamespaceUrl);
            manager.AddNamespace("saml", "urn:oasis:names:tc:SAML:2.0:assertion");
            manager.AddNamespace("samlp", "urn:oasis:names:tc:SAML:2.0:protocol");
            XmlNode node = xmlDoc.SelectSingleNode("/samlp:Response/saml:Assertion/saml:Subject/saml:NameID", manager);
            return node.InnerText;
        }
    }
    public class AuthRequest
    {
        public string id;
        private string issue_instant;
        public enum AuthRequestFormat
        {
            Base64 = 1
        }
        public AuthRequest()
        {
            id = "_" + System.Guid.NewGuid().ToString();
            issue_instant = DateTime.Now.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
        }
        public string GetRequest(AuthRequestFormat format)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlWriterSettings xws = new XmlWriterSettings();
                xws.OmitXmlDeclaration = true;
                using (XmlWriter xw = XmlWriter.Create(sw, xws))
                {
                    xw.WriteStartElement("samlp", "AuthnRequest", "urn:oasis:names:tc:SAML:2.0:protocol");
                    xw.WriteAttributeString("ID", id);
                    xw.WriteAttributeString("Version", "2.0");
                    xw.WriteAttributeString("IssueInstant", issue_instant);
                    xw.WriteAttributeString("ProtocolBinding", "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST");
                    xw.WriteAttributeString("AssertionConsumerServiceURL", "http://localhost/SAML2/POST"); // service provider url to consume token . it should be post method
                    xw.WriteAttributeString("Destination", "http://myshibboleth.idp.com/idp/profile/SAML2/Redirect/SSO");
                    //xw.WriteAttributeString("AssertionConsumerServiceURL", ConfigurationManager.AppSettings["AssertionConsumerServiceURL"]);
                    //xw.WriteAttributeString("Destination", ConfigurationManager.AppSettings["Destination"]);
                    xw.WriteStartElement("saml", "Issuer", "urn:oasis:names:tc:SAML:2.0:assertion");
                    xw.WriteString("http://localhost");  // service provider home url
                    xw.WriteEndElement();
                    xw.WriteStartElement("samlp", "NameIDPolicy", "urn:oasis:names:tc:SAML:2.0:protocol");
                    xw.WriteAttributeString("AllowCreate", "true");
                    xw.WriteEndElement();
                    //xw.WriteStartElement("samlp", "RequestedAuthnContext", "urn:oasis:names:tc:SAML:2.0:protocol");
                    //xw.WriteAttributeString("Comparison", "exact");
                    //xw.WriteStartElement("saml", "AuthnContextClassRef", "urn:oasis:names:tc:SAML:2.0:assertion");
                    //xw.WriteString("urn:oasis:names:tc:SAML:2.0:ac:classes:PasswordProtectedTransport");
                    //xw.WriteEndElement();
                    xw.WriteEndElement(); // RequestedAuthnContext
                }
                if (format == AuthRequestFormat.Base64)
                {
                    var bytes = Encoding.UTF8.GetBytes(sw.ToString());
                    using (var output = new MemoryStream())
                    {
                        using (var zip = new DeflateStream(output, CompressionMode.Compress))
                        {
                            zip.Write(bytes, 0, bytes.Length);
                        }
                        var base64 = Convert.ToBase64String(output.ToArray());
                        return base64;
                        //return HttpUtility.UrlEncode(base64);
                    }
                }
                return null;
            }
        }
    }
}
