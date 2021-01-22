        public string MakeRequest(string requestString, string serviceUrl, string headerUrl, string useragent)
        {
            string query = requestString.Replace(@"<sharedSecret></sharedSecret>", "<sharedSecret>"+secret+"</sharedSecret>");
            query = query.Replace(@"<SessionID></SessionID>", "<SessionID>" + secret + "</SessionID>");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(server + serviceUrl);
            //if (proxy != null) req.Proxy = new WebProxy(proxy, true);
            req.Headers.Add("SOAPAction", headerUrl);
            if (useragent == null)
                req.UserAgent = "SOAP Toolkit 3.0";
            else
            {
                req.UserAgent = useragent;
            }
            req.ContentType = "text/xml;charset=\"utf-8\"";
            req.Accept = "text/xml";
            req.Method = "POST";
            Stream stm = req.GetRequestStream();
            StreamWriter sw = new StreamWriter(stm);
            sw.Write(query);
            sw.Flush();
            stm.Close();
            WebResponse resp = req.GetResponse();
            stm = resp.GetResponseStream();
            StreamReader r = new StreamReader(stm);
            string response = (r.ReadToEnd());
            return response;
        }
