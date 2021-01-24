    public ActionResult MyPage(PageData pageData)
    {
       Session["SiteName"] = HttpContext.Request.Url.Segments.Last();
       return View();
    }
