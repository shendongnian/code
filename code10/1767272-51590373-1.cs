    public IActionResult GetCostumerType(int? id)
    {
       var test = from custom in _yourContext.CustomerType                   
                  .Where(p => p.CustomerType.Id == customerId)
                  select custom;
                  //change _yourContext with your context variable
                  //Remove toList() if you want to return only one
       return View(test);
    }
