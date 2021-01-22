    // WebClient vs HttpClient vs HttpWebRequest vs RestSharp
    // در نهایت به نظرم روش زیر سریعترین روشه
    HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(url);
    Request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
    Request.Proxy = null;
    Request.Method = "GET";
    using (WebResponse Response = Request.GetResponse())
    {
        using (StreamReader Reader = new StreamReader(Response.GetResponseStream()))
        {
            return Reader.ReadToEnd();
        }
    }
