    //
    // POST: /EmergencyServiceType/Create
    [HttpPost]
    public ActionResult Create(FOO_BAR_TYPE foobar)
    {
        if (ModelState.IsValid)
        {            
            // GetNextSequenceValue() deals with Oracle+EF issue with auto-increment IDs
            foobar.FOO_BAR_ID = _repo.GetNextSequenceValue(); 
            _repo.Add(foobar);
            _repo.SaveChanges();
            return RedirectToAction("Index");  
        }
    
        return View(foobar); // display the updated Model
    }
