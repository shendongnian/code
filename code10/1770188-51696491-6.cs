    public ActionResult ListPartial(string SPHostUrl)
    {
        var posts = db.Posts.ToList();
        ViewBag.SPHostUrl = SPHostUrl;
        return PartialView(posts);
    }
