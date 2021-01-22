    [HttpPost]
    public ActionResult Create(Person person, FormCollection collection)
    {
        if (ModelState.IsValid)
        {
            try
            {
                personRepository.Add(person);
                personRepository.Save();
                return RedirectToAction("Index");            
            }
            catch
            {
                return View(person);
            }
        }
        else
            return View(person);     
    }
