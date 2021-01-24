    [HttpPost]
    public ActionResult SecondStepProcessValid(CustomersModel model)
    {
        foreach (var c in model.Amount)
        {
            customerRepository.Create(c);
        }
        return View("ThirdStepProcess");
    }
    
