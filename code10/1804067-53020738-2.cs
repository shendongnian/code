    public ActionResult Edit(User user)
    { 
            if (ModelState.IsValid)
            {
                var OldInsObj = db.Users.Find(user.UserId);
                DateTime UsersDateCreated = OldInsObj.UsersDateCreated;
    
                OldInsObj = Mapper.Map(user);
    
                OldInsObj.UsersDateCreated = UsersDateCreated;
                OldInsObj.UsersDateModified = DateTime.Now;
    
                db.SaveChanges();
                return RedirectToAction("Index");
            }
     }
