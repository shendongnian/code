    // POST: Hostel/Create
        [HttpPost]
        public ActionResult Create(Hostel collection)
        {
            try
            {
                // TODO: Add insert logic here
                List<object> list = new List<object>();
                list.Add(collection.H_Name);
                list.Add(collection.H_Phone);
                list.Add(collection.H_Description);
                list.Add(collection.H_TotalBedrooms);
                list.Add(collection.H_WifiCharges);
                list.Add(collection.H_SecurityCharges);
                list.Add(collection.H_MonthyRent);
                list.Add(collection.H_Image);
                list.Add(collection.H_Avaliablity);
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
