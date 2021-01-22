    const int knownErrorCode = unchecked((int)0x800AC472);
    try
    {
        // Some COM code that could blow up
    }
    catch (COMException ex)
    {
        if (ex.ErrorCode == knownErrorCode ) 
        {
            // Do stuff
        }
    }
