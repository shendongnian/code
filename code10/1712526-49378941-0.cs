                string myurl = uri + uriTemplate;
                string soapAction = string.Empty;
                String Method = methodType;//Define your method
                try
                {
                    XmlDocument soapEnvelopeXml = new XmlDocument();
                    var strSOAPXML = (Y)obj;//obj would be your request object
                    soapEnvelopeXml.LoadXml(Convert.ToString(strSOAPXML));  
                    HttpWebRequest webRequest=(HttpWebRequest)WebRequest.Create(uri);
                    webRequest.Headers.Add("SOAPAction", soapAction + uriTemplate);
                    webRequest.ContentType = "text/xml;charset=\"utf-8\"";
                    webRequest.Accept = "text/xml";
                    webRequest.Method = Method.ToUpper();                
                    webRequest.KeepAlive = false;
                    using (Stream stream = webRequest.GetRequestStream())
                    { soapEnvelopeXml.Save(stream); }
                    // begin async call to web request.
                    IAsyncResult asyncResult = webRequest.BeginGetResponse(null, null);
                    // suspend this thread until call is complete
                    asyncResult.AsyncWaitHandle.WaitOne();
                    // get the response from the completed web request.
                    string soapResult;                
                    using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))
                    using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
                    {                    
                        soapResult = rd.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                   throw ex;
                }
                return _result;
