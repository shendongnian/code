    [HttpPost]
    public ActionResult SecondStepProcessValid(CustomersModel model)
    {
        foreach (var c in model.NewCustomers)
        {
            customerRepository.Create(c);
        }
        return View("ThirdStepProcess");
    }
