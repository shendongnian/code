    [HttpPost]
    public IActionResult AddPerson(GikFormViewModel formViewModel)
    {
        if(formViewModel.Items == null)
        {
            //formViewModel.Items.Add(new GikItemViewModel() { })
            formViewModel.Items = new List<GikItemViewModel>();
        }
        if (!ModelState.IsValid)
        {
            return View("Index", formViewModel);
        }
        //Save the model into the TempData object.
        TempData["model] = formViewModel;
        return RedirectToAction("SaveForm");
        //return View("Index", formViewModel);
    }
