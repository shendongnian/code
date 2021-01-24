    public ActionResult Edit(PayScale payscale)
    {
        if (ModelState.IsValid)
        {
            var existingEntry = db.Find(payscale);
            if(existingEntry != null)
            {
                 db.Entry(existingEntry).CurrentValues.SetValues(payscale);
                 db.SaveChanges();
            }
            else
            {
                 //Handle updating a missing record how you want
            }
            return RedirectToAction("Index");
        }
        return View(payscale);
    }
