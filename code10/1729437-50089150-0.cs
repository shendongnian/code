    [ChildActionOnly]
    public ActionResult Index()
    {
        var viewModel = YourViewModel();
        return PartialView(viewModel);
    }
