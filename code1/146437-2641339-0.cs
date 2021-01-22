        private CookieContainer _jar = new CookieContainer();
        private string _password;
        private string _userid;
        private string _url;
        private string _userAgent;
   ...
            string responseData;
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(_url);
            webRequest.CookieContainer = _jar;
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = _userAgent;
            string requestBody = String.Format(
                "client_id={0}&password={1}", _userid, _password);
            try
            {
                using (StreamWriter requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                {
                    requestWriter.Write(requestBody);
                    requestWriter.Close();
                    using (HttpWebResponse res = (HttpWebResponse)webRequest.GetResponse())
                    {
                        using (StreamReader responseReader = new StreamReader(res.GetResponseStream()))
                        {
                            responseData = responseReader.ReadToEnd();
                            responseReader.Close();
                            if (res.StatusCode != HttpStatusCode.OK)
                                throw new WebException("Logon failed", null, WebExceptionStatus.Success, res);
                        }
                    }
                }
