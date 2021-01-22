    try
    {
        if(User.IsUserAuthorizedToSignIn)
        {
            // Let the magic happen
        }
        else
        {
            // No rights
        }
    }
    catch(AuthorisationException e)
    {
        // Let the user know there is something up with the system. 
    }
