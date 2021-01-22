    // Test for required "FirstName".
       controller.ViewData.ModelState.Clear();
    
       newCustomer = new Customer
       {
           FirstName = "",
           LastName = "Smith",
           Zip = "34275",    
       };
    
       controller.Create(newCustomer);
    
       // Make sure that our validation found the error!
       Assert.IsTrue(controller.ViewData.ModelState.Count == 1, 
                     "FirstName must be required.");
