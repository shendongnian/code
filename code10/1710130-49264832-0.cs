    public ActionResult Edit( [Bind(Include = "Id,Description,Rate,Paid,Tech,Company")] TimeEntry timeEntry)
        {
            if (ModelState.IsValid)
            {
                Technician tech = db.Technician.Single(m => m.PhoneNumber == timeEntry.Tech.PhoneNumber);
                timeEntry.Tech = tech;
                Company comp = db.Companies.Single(m => m.Name == timeEntry.Company.Name);
                timeEntry.Company = comp;
                db.Entry(timeEntry).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(timeEntry);
        }
