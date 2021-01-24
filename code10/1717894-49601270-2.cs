    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SaveRegister(AirlineWebApplication.Models.User User,
        HttpPostedFileBase file)
    {
    
    	db.Users.Add(User);
    	db.SaveChanges();
        TempData["Referrer"] = "SaveRegister";
    	return RedirectToAction("Index");
    }
