    try
    {
        // ...
    }
    catch (FbException ex)
    {
        if (ex.ErrorCode == 335544726)
        {
            // close the connection (reopen depending on your application)
        }
        throw;
    }
