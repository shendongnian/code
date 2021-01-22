    private string sendRequest(string url, string method, string postdata) {
        WebRequest rqst = HttpWebRequest.Create(url);
        CredentialCache creds = new CredentialCache();
        creds.Add(new Uri(url), "Basic", new NetworkCredential(this.Uname, this.Pwd));
        rqst.Credentials = creds;
        rqst.Method = method;
        if (!String.IsNullOrEmpty(postdata)) {
            rqst.ContentType = "application/xml";
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(postdata);
            rqst.ContentLength = byteData.Length;
            using (Stream postStream = rqst.GetRequestStream()) {
                postStream.Write(byteData, 0, byteData.Length);
                postStream.Close();
            }
        }
        ((HttpWebRequest)rqst).KeepAlive = false;
        StreamReader rsps = new StreamReader(req.GetResponse().GetResponseStream());
        string strRsps = streamIn.ReadToEnd();
        return strRsps;
    }
