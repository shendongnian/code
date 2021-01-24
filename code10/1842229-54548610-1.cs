    // Populate select list
    [HttpGet]
    public IActionResult Change()
    {
        var model = new ViewModel();
        model.OptionList = new List<SelectListItem>();
        // populate list values here
        model.OptionList.Add(new SelectListItem { Text = "...", Value = "..." });
        return View(model);
    }
