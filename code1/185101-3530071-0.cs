    public ActionResult Index()
    {
        var xyzComponent = Request.Headers["xyzComponent"];
        var model = new MyModel 
        {
            IsCustomHeaderSet = (xyzComponent != null)
        }
        return View(model);
    }
