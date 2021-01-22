        try
        {
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.InnerXml = xmlfile.ToString();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(EndPoints);
            req.Timeout = 100000000;
            if (proxy != null)
                req.Proxy = new WebProxy(proxy, true);
            req.Headers.Add("SOAPAction", "");
            req.ContentType = "application/soap+xml;charset=\"utf-8\"";
            req.Accept = "application/x-www-form-urlencoded"; //"application/soap+xml";
            req.Method = "POST";
            Stream stm = req.GetRequestStream();
            doc.Save(stm);
            stm.Close();
            WebResponse resp = req.GetResponse();
            stm = resp.GetResponseStream();
            StreamReader r = new StreamReader(stm);
            string myd = r.ReadToEnd();
            return myd;
        }
