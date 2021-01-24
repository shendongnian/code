    public IActionResult GetCostumerType(int? id)
    {
       var test = (from custom in _yourContext.GetCustomerType                   
                  .Where(p => p.GetCustomerType.Id == customerId)
                  select custom).ToList();
                  //change _yourContext with your context variable
                  //Remove toList() if you want to return only one
       return View(test);
    }
