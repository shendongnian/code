    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult DoStuff(IEnumerable<Link> saveList)
    {
        Repository.SaveLinks(saveList);
        return Json(true);
    }
