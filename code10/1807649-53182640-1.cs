    [HttpPost]
    public ActionResult Save(Customer customer)
    {
        if (ModelState.IsValid)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb = customer;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        else
        {
            // validation failed, show the form again with validation errors
            return View(customer);
        }
    }
