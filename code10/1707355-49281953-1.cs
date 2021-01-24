     public ActionResult UpdateUser(User newUser)
        {
            newUser.City = new City { Id = Convert.ToInt32(fdata["CityList"]) };
            dbcontext db = new dbcontext();
            if (ModelState.IsValid)
            {
                using (db)
                {
                    User oldUser = db.Users.Find(newUser.Id);
                    oldUser.Role = newUser.Role;
                    db.Entry(newUser.Role).State = EntityState.Unchanged;
                    db.SaveChanges();
                    return View();
                }
