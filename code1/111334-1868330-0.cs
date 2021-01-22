    bool helper_success = false; 
    bool automatic_retry = false; 
    //run initial process
    try
    {
        //call helper method
        HelperMethod();
        helper_success = true; 
    }
    catch(Exception e)
    {
        // check if e is a transient exception. If so, set automatic_retry = true 
    } 
    
    
    if (automatic_retry)
    {    //try catch statement for second process.
        try
        {
            HelperMethod();
        }
        catch(Exception e)
        {
            throw;
        }
    }
