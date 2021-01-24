    public class EoriModel
        {
            string _url;
    
            public EoriModel()
            {
                _url = "http://ec.europa.eu/taxation_customs/dds2/eos/validation/services/validation";  
            }
    
            public EoriResponseModel ValidateEoriNumber(string number)
            {
                if (number == null)
                {
                    return null;
                }
    
                XmlDocument soapEnvelopeXml = CreateSoapEnvelope(number);
                HttpWebRequest webRequest = CreateWebRequest(_url);
                InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);
    
                IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
                asyncResult.AsyncWaitHandle.WaitOne();
    
                string response;
                using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                {
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {
                        response = rd.ReadToEnd();
                    }
                }
    
                int startPos = response.IndexOf("<return>");
                int lastPos = response.LastIndexOf("</return>") - startPos + 9;
                string responseFormatted = response.Substring(startPos, lastPos);
    
                XmlSerializer serializer = new XmlSerializer(typeof(EoriResponseModel));
                EoriResponseModel result; 
                
                using (TextReader reader = new StringReader(responseFormatted))
                {
                    result = (EoriResponseModel)serializer.Deserialize(reader);
                }
                
                return result;
            }
    
            private static HttpWebRequest CreateWebRequest(string url)
            {
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                webRequest.Accept = "text/xml";
                webRequest.Method = "POST";
                return webRequest;
            }
    
            private static XmlDocument CreateSoapEnvelope(string number)
            {
                XmlDocument soapEnvelopeDocument = new XmlDocument();
                StringBuilder xmlBuilder = new StringBuilder();
                xmlBuilder.AppendFormat("<soap:Envelope xmlns:soap={0} >", "'http://schemas.xmlsoap.org/soap/envelope/'");
                xmlBuilder.Append("<soap:Body>");
                xmlBuilder.AppendFormat("<ev:validateEORI xmlns:ev={0} >", "'http://eori.ws.eos.dds.s/'");
                xmlBuilder.AppendFormat("<ev:eori>{0}</ev:eori>", number);
                xmlBuilder.Append("</ev:validateEORI>");
                xmlBuilder.Append("</soap:Body> ");
                xmlBuilder.Append("</soap:Envelope> ");
    
                soapEnvelopeDocument.LoadXml(xmlBuilder.ToString());
                return soapEnvelopeDocument;
            }
    
            private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
            {
                using (Stream stream = webRequest.GetRequestStream())
                {
                    soapEnvelopeXml.Save(stream);
                }
            }
        }
