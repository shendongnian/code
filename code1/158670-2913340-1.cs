    [HttpPost]
    public ActionResult UpdateComplexObject(string id, CustomerViewModel customerViewModel) {
    // if (!id.Equals(customerViewModel.Customer.Id) throw something
    // just one of my own conventions to ensure that I am working on the correct active
    // entity - string id is bound from the route rules.
    ValidateModel(customerViewModel);
    service.UpdateCustomer(customerViewModel.Customer);
    serviceOrder.UpdateOrder(customerViewModel.ActiveOrder);
    serviceAddress.UpdateAddress(customerViewModel.Address);
    return RedirectToAction("DisplayComplexObject"); // or whatever
    }
