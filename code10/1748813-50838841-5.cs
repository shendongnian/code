    [ValidateCustomerModel]
    [HttpPost]
    public  ActionResult Create(MyModel customerDatabase) {
        if(ModelState.IsValid) {
            //...
            
        }
        
        return View(customerDatabase);
    }
    
