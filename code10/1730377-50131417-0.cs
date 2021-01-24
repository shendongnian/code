    public static SPContext FakeSPContext(SPWeb web)
    {
        if (HttpContext.Current == null)
        {
            HttpRequest request = new HttpRequest("", web.Url, "");
            HttpContext.Current = new HttpContext(request, new HttpResponse(TextWriter.Null));
        }
     
        if (HttpContext.Current.Items["HttpHandlerSPWeb"] == null)
        {
            HttpContext.Current.Items["HttpHandlerSPWeb"] = web;
        }
     
        return SPContext.Current;
    }
