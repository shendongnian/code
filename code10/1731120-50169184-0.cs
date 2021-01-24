    public ActionResult dropdown() {
        var customers = new List<Customer>();
        customers.Add(new Customer { Name = "Airi Satou", ID = 1 });
        customers.Add(new Customer { Name = "Brenden Wagner", ID = 2 });
        customers.Add(new Customer { Name = "Brielle Williamson", ID = 2 });
        ViewBag.DropData = customers;
        return View();
    }
		
