	public ActionResult Index(string id)
	{
		Artikel model = Database.GetArticle(id);
		return View(model);
	}
