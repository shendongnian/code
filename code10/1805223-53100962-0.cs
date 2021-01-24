    public virtual ActionResult AddCustomer(CustomerAddViewModel model)
    {            
        if (!string.IsNullOrEmpty(model.Email))
        {
          var exists = _userService.UserExists(model.Email);
          if (exists) 
          { 
            ModelState.AddModelError("Email", "Email Already Exists"); 
           }
        }
    }
