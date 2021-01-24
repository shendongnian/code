    [HttpPost]
    public ActionResult Register(UserVM obj)
    {
        if (ModelState.IsValid)
        {
            var isEmailAlreadyExists = db.User.Any(x => x.Email == obj.Email);
            if(isEmailAlreadyExists)
            {
                ModelState.AddModelError("Email", "User with this email already exists");
                return View(obj)
            }
            
            User newobj = new User();
            newobj.UserName = obj.UserName;
            newobj.Email = obj.Email;
            newobj.Password = obj.Password;
            newobj.Address = obj.Address;
            db.User.Add(newobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
        return View(obj)
    }
