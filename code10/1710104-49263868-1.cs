    public ActionResult Update(IEnumerable<ApplicationUser> usersToActivate)
    {
		// Are there any user to active?
		if (usersToActivate == null)
		{
			return View();
		}
		
		var userIds = usersToActivate.Select(u => u.Id).ToList();
		var usersToUpdate = context.Users.Where(user => userIds.Contains(user.Id));
    
		foreach (var userToUpdate in usersToUpdate)
		{
			userToUpdate.activated = "Yes";
		}
		
		context.SaveChanges();
		
        return RedirectToAction("Index")
    }
