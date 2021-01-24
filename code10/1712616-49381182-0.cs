    public ActionResult Admin()
    {
       string currentUrl = HttpContext.Request.Url.Segments.Last();
       //per session (let's say: per user)
       //you can read and write to this variable
       Session["SiteName"] = currentUrl;   
       //"global" variables: for all users
       HttpContext.Application["SiteName"] = currentUrl;
            
       return View();
    }
    
