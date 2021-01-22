    public ActionResult GetInstance(string id)
    {
    	MyContent content = GetContentFromDatastore(id);
    	return View(content);
    }
