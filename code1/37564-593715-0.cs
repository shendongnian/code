    string url = HttpContext.Current.Request.Url.AbsoluteUri;
    // http://localhost:1302/TESTERS/Default6.aspx
    string path = HttpContext.Current.Request.Url.AbsolutePath;
    // /TESTERS_HERE/Default6.aspx
    string host = HttpContext.Current.Request.Url.Host;
    // localhost
