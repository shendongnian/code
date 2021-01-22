    string errorMessage = string.empty;
    
    try
    {
    ...
    }
    catch(Exception e)
    {
       errorMessage = e.Message + e.StackTrace;;
    }
