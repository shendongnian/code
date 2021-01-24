       public ActionResult InsertDetail()
        {
            string poN = Request.Form["entityNum"];
            var thisEntty = _context.entityDB.FirstOrDefault(p => p.Entity.Equals(entityNum));
    
            if (thisEntity != null) // same entity exists!
            {
               ModelState.AddModelError("", "Data Already Exists");
               return View("Insert");
            }
        }
