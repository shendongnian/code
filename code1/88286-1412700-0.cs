    // main form
    try
    {
        User _loggedOnUser = User.GetLoggedOnUser();
    }
    catch (AuthenticationException ex)
    {
        MessageBox.Show(this, ex.Message, "Unable to authenticate user");
    }
    
    
    // Auth class
    // ... do something
    if (something == true)
        throw new AuthenticationException("User account has been disabled");
