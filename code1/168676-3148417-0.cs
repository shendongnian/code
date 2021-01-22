        XDocument ConstructSoapEnvelope(string messageId, string action, XDocument body)
        {
            XDocument xd = new XDocument();
            XNamespace s = "http://schemas.xmlsoap.org/soap/envelope/";
            XNamespace a = "http://www.w3.org/2005/08/addressing";
            XElement soapEnvelope = new XElement(s + "Envelope", new XAttribute(XNamespace.Xmlns + "s", s), new XAttribute(XNamespace.Xmlns + "a", a));
            XElement header = new XElement(s + "Header");
            XElement xmsgId = new XElement(a + "MessageID", "uuid:" + messageId);
            XElement xaction = new XElement(a + "Action", action);
            header.Add(xmsgId);
            header.Add(xaction);
            XElement soapBody = new XElement(s + "Body", body.Root);
            soapEnvelope.Add(header);
            soapEnvelope.Add(soapBody);
            xd = new XDocument(soapEnvelope);
            return xd;
        }
        string HttpSOAPRequest(XmlDocument doc, string add, string proxy, X509Certificate2Collection certs)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(add);
            req.ClientCertificates = certs;
            if (proxy != null) req.Proxy = new WebProxy("", true);
   
            req.Headers.Add("SOAPAction", "\"\"");
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";
            Stream stm = req.GetRequestStream();
            doc.Save(stm);
            stm.Close();
            WebResponse resp = req.GetResponse();
            stm = resp.GetResponseStream();
            StreamReader r = new StreamReader(stm);
          
           return r.ReadToEnd();
        }
