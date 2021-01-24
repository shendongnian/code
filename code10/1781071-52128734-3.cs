    public ActionResult Index()
    {
        //The below query replace by yours
        var projects = db.ProjectCategories.ToList();
        List<SelectListItem> dropDownItems1 = projects.Select(c => new SelectListItem { Text = c.title, Value = c.id.ToString() }).ToList();
        ViewBag.proj = dropDownItems1;
        //The below query replace by yours
        var funds = db.FundCategories.ToList();
        List<SelectListItem> dropDownItems2 = funds.Select(c => new SelectListItem { Text = c.title, Value = c.id.ToString() }).ToList();
        ViewBag.funds = dropDownItems2;
        ProjectFundViewModel viewModel = new ProjectFundViewModel
        {
            ProjectCategories = projects,
            FundCategories = funds
        };
        return View(viewModel);
    }
