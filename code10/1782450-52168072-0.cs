    [HttpPost, Authorize]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "CompanyName,Telephone")]Company company)
    {
        try
        {
            if (ModelState.IsValid)
            {
                company.Id = int.Parse(User.Identity.GetUserId());
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        catch (DataException /* dex */)
        {
            ModelState.AddModelError("", "Unable to save changes.");
        }
    
        return View(company);
    }
