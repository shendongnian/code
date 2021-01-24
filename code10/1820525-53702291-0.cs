    var url = "http://poe.trade/search/arokazugetohar";
    
    HtmlWeb webClient = new HtmlWeb();
    HtmlAgilityPack.HtmlWeb.PreRequestHandler handler = delegate (HttpWebRequest request)
    {
        request.Headers[HttpRequestHeader.AcceptEncoding] = "gzip, deflate";
        request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        request.CookieContainer = new System.Net.CookieContainer();
        return true;
     };
     webClient.PreRequest += handler;
    
     HtmlDocument doc = webClient.Load(url);
