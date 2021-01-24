    // Populate select list
    [HttpGet]
    public IActionResult Change()
    {
        var model = new ViewModel();
        model.OptionList = new List<SelectListItem>();
        // populate list values here
        model.OptionList.Add(new SelectListItem { Text = "1001", Value = "Vilnius", Selected = true });
        model.OptionList.Add(new SelectListItem { Text = "1002", Value = "Trakai", Selected = false });
        return View(model);
    }
