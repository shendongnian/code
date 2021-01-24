    public ActionResult Index(int? id)
    {
        if(id != null)
        {
            return StatusCode(404);
        }
        ...
        return View();
    }
