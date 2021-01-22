    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Edit(int id, FormCollection formValues) {
        Contact contact = repository.GetById(id);
        try {
            UpdateModel(contact);
            repository.Save(contact);
            return RedirectToAction("Details", new { id=contact.Id });
        }
        catch(Exception ex) {
            // Do something...
        }
 
        return View(contact);
    }
