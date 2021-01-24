    public ActionResult Index()
    {
        var projects = db.ProjectCategories.ToList();
    
        List<SelectListItem> dropDownItems1 = projects.Select(c => new SelectListItem { Text = c.id.ToString(), Value = c.id.ToString() }).ToList();
        ViewBag.ids = dropDownItems1;
    
        List<SelectListItem> dropDownItems2 = projects.Select(c => new SelectListItem { Text = c.title, Value = c.title }).ToList();
        ViewBag.titles = dropDownItems2;
    
        ProjectFundViewModel viewModel = new ProjectFundViewModel
        {
            ProjectCategories = projects,
        };
    
        return View(viewModel);
    }
