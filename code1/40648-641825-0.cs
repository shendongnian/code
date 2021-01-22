    HttpResponse Response = context.Response
    Response.ContentType = "text/plain";
    Response.CharSet = "Windows-1252";
    Response.AddFileDependency(filePath);
    // Set additional properties to enable caching.
    Response.Cache.SetExpires(DateTime.Now.AddSeconds(60));
    Response.Cache.SetCacheability(HttpCacheability.Public);
    Response.Cache.SetValidUntilExpires(true);
    Response.TransmitFile(filePath);
