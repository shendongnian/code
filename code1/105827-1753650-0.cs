    public ActionResult Verify(Nullable<Guid> id)
    {
        if (!id.HasValue)
        {
            // nothing was submitted
            ViewData["message"] = "Please enter your ID and press Submit";
            return View("Verify");
        }
        if (!ValidId(id))
        {
            // something was submitted, but wasn't valid
            ViewData["message"] = "ID is invalid or incomplete. Pleaes check your speeling";
            return View("Verify");
        }
        // must be valid
        return RedirectToAction("Index", "Dashboard");
    }
