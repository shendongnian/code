    try 
    {
         //Some db access has failed
    }
    catch(DbOfflineException ex)
    { 
        // Show message box to user 
        // Notify IS DB Team about critical issue
        // Rethrow if our calling method also has a try catch
    }
    catch(Exception ex)
    {
        // If the exception isn't of type DbOfflineException we
        // would get to this catch block and could handle differently
    }
