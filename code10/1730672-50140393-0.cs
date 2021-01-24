    private const string IEUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; Trident/5.0)";
    public ActionResult Index()
    {
        string userAgent = HttpContext.Current.Request.UserAgent;
   
        if (userAgent == IEUserAgent) 
        {
           return View("IE9View");
        }
        return View();
    }
