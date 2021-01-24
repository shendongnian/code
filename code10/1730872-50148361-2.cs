    public ActionResult Index(string id)
    {
        if(id != null)
        {
            return StatusCode(404);
        }
        ...
        return View();
    }
