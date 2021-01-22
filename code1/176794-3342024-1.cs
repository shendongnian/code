    public ActionResult Index()
    {
        var model = new MyModel
        {
            NumOfGroups = 15
        };
        return View(model);
    }
