    DateTime datePosted;
    if (!DateTime.TryParse(Request.Form["datepicker"], out datePosted))
    {
        this.ModelState.AddModelError("datepicker", "Invalid Date!");
    }
    
    if (this.ModelState.IsValid)
    {
        return View("show", nastava);
    }
    else
    {
        // return your GET edit action here
        return Edit(5);
    }
