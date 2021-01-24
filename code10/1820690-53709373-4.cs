       public ActionResult Edit(int id)
                {
                    Customer customer = _context.Customers.SingleOrDefault(x => x.Id == id);
                    if (customer == null)
                        return HttpNotFound();
        
                    CustomerViewModel viewModel = new CustomerViewModel()
                    {
                        Customer = customer,
                        Type = _context.Type
                    };
        
                    return View("Customer_Form", viewModel);
                }
