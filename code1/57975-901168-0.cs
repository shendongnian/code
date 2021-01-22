    public static HttpWebResponse HttpPost(String url, String referer, String userAgent, ref CookieCollection cookies, String postData, out WebHeaderCollection headers, WebProxy proxy)
        {
            try
            {
                HttpWebRequest http = WebRequest.Create(url) as HttpWebRequest;
                http.Proxy = proxy;
                http.AllowAutoRedirect = true;
                http.Method = "POST";
                http.ContentType = "application/x-www-form-urlencoded";
                http.UserAgent = userAgent;
                http.CookieContainer = new CookieContainer();
                http.CookieContainer.Add(cookies);
                http.Referer = referer;
                byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
                http.ContentLength = dataBytes.Length;
                using (Stream postStream = http.GetRequestStream())
                {
                    postStream.Write(dataBytes, 0, dataBytes.Length);
                }
                HttpWebResponse httpResponse = http.GetResponse() as HttpWebResponse;
                headers = http.Headers;
                cookies.Add(httpResponse.Cookies);
                
                return httpResponse;
            }
            catch { }
            headers = null;
            
            return null;
        }
