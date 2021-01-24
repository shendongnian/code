         [HttpPost]
        public ActionResult Create([Bind(Include = Entities)]  EntityModel model)
        {
          //If something goes wrong return to the form with the errors.
          if(!ModelState.isValid()) return Create(model);
          
           //If everything goes well, redirect to another form
             return RedirectToAction("AnotherForm", "Event", new { id = 
    
         
          return View(model);
        }
