    public IActionResult Index(string environment, string mode)
    {
        var model = new CombinedViewModel ();
        model.Environment = environment;
        model.SecondViewModel = new SecondViewModel();
        model.SecondViewModel.Mode = mode;
        return View(model);
    }
