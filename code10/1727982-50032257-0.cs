    [HttpPost]
    public ActionResult CreateCompany(Company comp)
        {
            ViewBag.CompanyType = GenericMethods.GetGenericPicks2("CompanyType2").OrderBy(e => e.Name);
            ViewBag.CompanyIndustry = GenericMethods.GetGenericPicks2("CompanyIndustry").OrderBy(e => e.Name);
            if (ModelState.IsValid)
            {
                Response.Write("Saving to DB");
                // code to save to database, redirect to other page
                return View(comp);
            }
            else
            {
                return View(comp);
            }
        }
