    public ActionResult MyPage2(PageData pageData)
    {
       var SiteName = Session["SiteName"].ToString();
       return View();
    }
