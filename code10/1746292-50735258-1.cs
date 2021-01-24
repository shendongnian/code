    try
    {
        // ...
    }
    catch (FbException ex)
    {
        if (ex.ErrorCode == 335544726)
        {
            // close the connection (and open a new one depending on your application)
        }
        throw;
    }
