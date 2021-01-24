    //modify signature to remove passing a Rent object it
    //you can create this object inside of this method
    //and do not need to pass one in so remove it from the method signature
    [HttpPost]
    public ActionResult Create(string carId)
    {
        if (!ModelState.IsValid)
            return View();
    
        var carToRent = context.Cars.SingleOrDefault(c => c.Id == carId);
    
        if (carToRent == null)
            return Content($"Car not found!");
    
        var rent = new Rent(); //this line has been added since the method signature was changed
        rent.Car = carToRent;
    
        var customer = context.Customers.SingleOrDefault(c => c.UserId == User.Identity.Name);
    
        if (customer == null)
            return Content($"Customer not found!");
    
        rent.Customer = customer;
    
        context.Rents.Add(rent);
        context.SaveChanges();
    
        return RedirectToAction("Index");
    }
