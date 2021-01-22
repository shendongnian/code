    public ActionResult Create([Bind(Include = "ID,Name,Description,Types")] YourEntity event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(event);
        }
