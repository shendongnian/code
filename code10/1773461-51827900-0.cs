    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(UserDetailsViewModel model) // Changed the input parmater
    {
        if (ModelState.IsValid)
        {
            var userDto = model.User; // read the user from view model
            var applicationUser = _context.Users.Find(userDto.Id);
            applicationUser.FirstName = userDto.FirstName;
            applicationUser.Surname = userDto.Surname;
            applicationUser.Email = userDto.Email;
            applicationUser.EmailConfirmed = userDto.EmailConfirmed;
            applicationUser.LockoutEndDateUtc = userDto.LockoutEndDateUtc;
            applicationUser.LockoutEnabled = userDto.LockoutEnabled;
            applicationUser.AccessFailedCount = userDto.AccessFailedCount;
            _context.SaveChanges();
            return View(new UserDetailsViewModel(userDto));
        }
    
        return View("Details", new UserDetailsViewModel(userDto));
    }
