    public ActionResult Get()
    {
       var viewModel = constructViewModel();
       return View(viewModel);
    }
    
    public ActionResult Post(ViewModelChanges changes)
    {
      var viewModel = constructViewModel();
      viewModel.SomeProperty = changes.SomeProperty;
      return View(viewModel);
    }
