    public ActionResult Index()
    {
        _customerService.DoOtherStuff();
        var name = _customerService.GetName();
        return View();
    }
