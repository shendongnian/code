    try
    {
        UserAccount newAccount = accountThingy.Create(account);
    }
    catch (UserNameAlreadyExistsException unaex)
    {
        MessageBox.Show(unaex.Message);
        return; // or do whatever here to cancel proceeding
    }
    catch (SomeOtherCustomException socex)
    {
        MessageBox.Show(socex.Message);
        return; // or do whatever here to cancel proceeding
    }
    // If this is as high up as an exception in the app should bubble up to, 
    // I'll catch Exception here too
