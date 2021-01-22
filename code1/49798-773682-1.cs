    private string sendRequest(string url, string method, string postdata) {
        WebRequest rqst = HttpWebRequest.Create(url);
        
        // only needed, if you use HTTP AUTH
        //CredentialCache creds = new CredentialCache();
        //creds.Add(new Uri(url), "Basic", new NetworkCredential(this.Uname, this.Pwd));
        //rqst.Credentials = creds;
        rqst.Method = method;
        if (!String.IsNullOrEmpty(postdata)) {
            //rqst.ContentType = "application/xml";
            rqst.ContentType = "application/x-www-form-urlencoded";
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(postdata);
            rqst.ContentLength = byteData.Length;
            using (Stream postStream = rqst.GetRequestStream()) {
                postStream.Write(byteData, 0, byteData.Length);
                postStream.Close();
            }
        }
        ((HttpWebRequest)rqst).KeepAlive = false;
        StreamReader rsps = new StreamReader(rqst.GetResponse().GetResponseStream());
        string strRsps = rsps.ReadToEnd();
        return strRsps;
    }
