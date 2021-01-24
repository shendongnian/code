    public ActionResult Index()
    {
       var vm = new VehicleDetailsViewController();
       return View(vm);
    }
    [HttpPost]
    public ActionResult Index(VehicleDetailsViewController vm)
    {
       //Validation something wrong
        if (!ModelState.IsValid) return View(vm);
       //Make what you want with all OK
        return View("AllOk");
    }
