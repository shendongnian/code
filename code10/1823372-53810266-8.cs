    public ActionResult Create([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate,Email,DepartmentId,Position,Active")] User user)
    {
        if (ModelState.IsValid)
        {
           _db.Users.Add(user);
           _db.SaveChanges();
           return RedirectToAction("Index");
        }
        return View(user);
    } 
