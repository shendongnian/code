    // GET: CarAuction/Edit/5
    public ActionResult Edit(int id= 3)
    {
            
        CarList carList = db.CarLists.Find(id);
            
        // Change this:
        return View(carList);
    }
