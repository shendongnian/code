    bool wasPasswordProtected;
    
    try
    {
        myWorksheet.Unprotect(string.Empty);
     
        // Unprotect suceeded:
        wasPasswordProtected = false;  
    }
    catch
    {
        // Unprotect failed:
        wasPasswordProtected = true;
    }
