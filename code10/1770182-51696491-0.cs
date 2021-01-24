    public ActionResult MyPartial1(string SPHostUrl)
    {
        var posts = db.Posts.ToList();
        ViewBag.SPHostUrl = SPHostUrl;
        return PartialView("_MyList", posts);
    }
