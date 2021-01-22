            public string GetFinalRedirectedUrl(string url)
        {
            string result = string.Empty;
            Uri Uris = new Uri(url);
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(Uris);
            //req3.Proxy = proxy;
            req.Method = "HEAD";
            req.AllowAutoRedirect = false;
            HttpWebResponse myResp = (HttpWebResponse)req.GetResponse();
            if (myResp.StatusCode == HttpStatusCode.Redirect)
            {
                string temp = myResp.GetResponseHeader("Location");
                //Recursive call
                result = GetFinalRedirectedUrl(temp);
            }
            else
            {
                result = url;
            }
            return result;
        }
