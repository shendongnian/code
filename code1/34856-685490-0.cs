    internal static string CallWebServiceDetail(string url, string soapbody, 
    int timeout) {
    	return CallWebServiceDetail(url, soapbody, null, null, null, null, 
    null, timeout);
    }
    internal static string CallWebServiceDetail(string url, string soapbody, 
    string proxy, string contenttype, string method, string action, 
    string accept, int timeoutMilisecs) {
    	var req = (HttpWebRequest) WebRequest.Create(url);
    	if (action != null) {
    		req.Headers.Add("SOAPAction", action);
    	}
    	req.ContentType = contenttype ?? "text/xml;charset=\"utf-8\"";
    	req.Accept = accept ?? "text/xml";
    	req.Method = method ?? "POST";
    	req.Timeout = timeoutMilisecs;
    	if (proxy != null) {
    		req.Proxy = new WebProxy(proxy, true);
    	}
    
    	using(var stm = req.GetRequestStream()) {
    		XmlDocument doc = new XmlDocument();
    		doc.LoadXml(soapbody);
    		doc.Save(stm);
    	}
    	using(var resp = req.GetResponse()) {
    		using(var responseStream = resp.GetResponseStream()) {
    			using(var reader = new StreamReader(responseStream)) {
    				return reader.ReadToEnd();
    			}
    		}
    	}
    }
