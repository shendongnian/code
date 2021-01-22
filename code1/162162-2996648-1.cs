    private bool ValidateLogin(string userEmail, string password)
    {
        if (String.IsNullOrEmpty(userEmail))
        {
            ModelState.AddModelError("username", "You must specify a username.");
        }
                
    
        if (password == null || password.Length == 0)
        {
            ModelState.AddModelError("password",
                   String.Format(CultureInfo.CurrentCulture,
                   "You must specify a password."));
        }
    
        return ModelState.IsValid;
     }
