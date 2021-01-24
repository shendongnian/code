    public ActionResult OnPostConnexion(viewModel model)
    {
        if (!ModelState.IsValid)
        {
           return View(model);
        }
        else
        {
            //do stuff
        }
    }
