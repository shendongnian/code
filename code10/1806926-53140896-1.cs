    // POST: Hostel/Create
        [HttpPost]
        public ActionResult Create(Hostel collection)
        {
            try
            {
                // TODO: Add insert logic here
              
                //simply remove query and let entity framework to help you with that 
                db.Hostels.Add(collection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
