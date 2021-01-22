     if(your custom validation fails....)
     {
         ModelState.AddModelError("Error1", "Your Error message1");
         ModelState.AddModelError("Error2", "Your Error message2");
     }
     if (!ModelState.IsValid)
     {
         return new JsonResult() { Data = GetModelStateErrors(ModelState)};
     }
    
     private static Collection<string> GetModelStateErrors(ModelState modelState)
      {
           Collection<string> errors = new Collection<string>();
    
           foreach (var item in modelState.Values)
           {
                foreach (var item2 in item.Errors)
                {
                    if (!string.IsNullOrEmpty(item2.ErrorMessage))
                    {
                        errors.Add(item2.ErrorMessage);
                                                   
                    }
                }
           }
           return errors;
      }
