    //get rid of parameter model, access directly in method body
        public async Task<IActionResult> OnPostAsync()
        {
    
          user = await _userManager.GetUserAsync(User);
                    
          user.name = Input.name;
          user.surname = Input.surname;
          user.street = Input.street;
          user.streetnumber = Input.streetnumber;
          user.city = Input.city;
          user.zipcode = Input.zipcode;
                    
          var result = await _userManager.UpdateAsync(user);
                          
          return RedirectToPage();
    
        }
