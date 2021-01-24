        public void add()
        {
            var _url = "http://www.dneonline.com/calculator.asmx";
            var _action = "http://www.dneonline.com/calculator.asmx?op=Add";
            string methodName = "Add";
            XmlDocument soapEnvelopeXml = CreateSoapEnvelope(methodName);
            HttpWebRequest webRequest = CreateWebRequest(_url, _action);
            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
            // begin async call to web request.
            IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
            // suspend this thread until call is complete. You might want to
            // do something usefull here like update your UI.
            asyncResult.AsyncWaitHandle.WaitOne();
            // get the response from the completed web request.
            string soapResult;
            using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
            {
                using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
                Console.Write(soapResult);
            }
        }
        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPAction", action);
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }
        private static XmlDocument CreateSoapEnvelope(string methodName)
        {
            XmlDocument soapEnvelopeDocument = new XmlDocument();
            string soapStr =
                       @"<?xml version=""1.0"" encoding=""utf-8""?>
                        <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance""
                           xmlns:xsd=""http://www.w3.org/2001/XMLSchema""
                           xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                          <soap:Body>
                            <{0} xmlns=""http://tempuri.org/"">
                              {1}
                            </{0}>
                          </soap:Body>
                        </soap:Envelope>";
            string postValues = "";
            Dictionary<string, string> Params = new Dictionary<string, string>();
            //< "name" > Name of the WebMethod parameter (case sensitive)</ param >
            //< "value" > Value to pass to the paramenter </ param >
            Params.Add("intA", "5"); // Add parameterName & Value to dictionary
            Params.Add("intB", "10");
            foreach (var param in Params)
            {
                postValues += string.Format("<{0}>{1}</{0}>", param.Key, param.Value);
            }
            soapStr = string.Format(soapStr, methodName, postValues);
            soapEnvelopeDocument.LoadXml(soapStr);
            return soapEnvelopeDocument;
        }
        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            try
            {
                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
            }
            catch (Exception ex)
            {
            }
        }
