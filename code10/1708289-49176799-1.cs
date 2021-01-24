    public ActionResult CheckProfile()
    {
        string userId = User.Identity.GetUserId();
        bool profileExists = HasProfile(userId);
        if(profileExists)
        {
            return RedirectToAction("GetNAA_Profile2", new { UserId = userId, Controller = "NAAProfile" });
        }
        else
        {
            return RedirectToAction("NoProfile", ...);
        }
    }
