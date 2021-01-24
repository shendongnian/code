    [HttpPost]
    public ActionResult EditDetails(UserDetails userDetails)
    {
        // note: the second overload is routeValues
        return RedirectToAction("Edit", userDetails.Id);
    }
    
    [HttpGet]
    public ActionResult Edit(int id)
    {
       var viewModel = service.GetUserViewModel(id);
       return View(viewModel); // reponse the ValidateLogin view
    }
