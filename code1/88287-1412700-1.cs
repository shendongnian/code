    // main form
    try
    {
        User _loggedOnUser = Authenticate.GetLoggedOnUser();
    }
    catch (AuthenticationException ex)
    {
        MessageBox.Show(this, ex.Message, "Unable to authenticate user");
    }
    
    
    // Authenticate class
    // ... do something
    if (something == true)
        throw new AuthenticationException("User account has been disabled");
