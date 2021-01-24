    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Text;
    public string WebClient_DownLoadString(Uri URI)
    {
        using (WebClient webclient = new WebClient())
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            webclient.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            webclient.Headers.Add(HttpRequestHeader.Accept, "ext/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.AcceptLanguage, "en-US,en;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate;q=0.8");
            webclient.Headers.Add(HttpRequestHeader.KeepAlive, "keep-alive");
            string result = webclient.DownloadString(URI);
            using (HttpWebResponse wc_response = (HttpWebResponse)webclient
                            .GetType()
                            .GetField("m_WebResponse", BindingFlags.Instance | BindingFlags.NonPublic)
                            .GetValue(webclient))
            {
                Encoding PageEncoding = Encoding.GetEncoding(wc_response.CharacterSet);
                byte[] bresult = webclient.Encoding.GetBytes(result);
                using (MemoryStream memstream = new MemoryStream(bresult, 0, bresult.Length))
                using (StreamReader reader = new StreamReader(memstream, PageEncoding))
                {
                    memstream.Position = 0;
                    return reader.ReadToEnd();
                };
            };
        }
    }
