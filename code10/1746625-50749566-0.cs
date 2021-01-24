    [HttpPost]
    public ActionResult GCLandingAddUser(GUser g)
    {    
        if (ModelState.IsValid) 
        {
            // So something      
            return RedirectToAction("Index");
        }
        g.CompanyList = GetSelectList(); // <------
        return View("AddGCLUser", g);
    }
