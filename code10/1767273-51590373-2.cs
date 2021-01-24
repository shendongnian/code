    public IActionResult GetCostumerType(int? id)
    {
       
       if (id == null)
       {
          return NotFound();
       }
    
       var test = from custom in _yourContext.CustomerType                   
                  .Where(p => p.CustomerType.Id == customerId)
                  select custom;
                  //change _yourContext with your context variable
                  //Remove toList() if you want to return only one
    
       if (test == null)
       {
         return NotFound();
       }
    
       return View(test);
    }
