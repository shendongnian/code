    var user = new AppUser {
                         UserName = Input.Email, 
                         Email = Input.Email,
                         Type1= new Type1{ Property1="Admin"} 
               };
    var result = await _userManager.CreateAsync(user, Input.Password);
